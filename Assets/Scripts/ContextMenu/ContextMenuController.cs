using MurderByDeath.Data;
using MurderByDeath.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MurderByDeath.ContextMenu
{
    public class ContextMenuController : MonoBehaviour
    {
        [SerializeField]
        private ContextMenuUI _menuUI;

        private EventController _eventController;
        private InteractiveObject _currentObject;

        private void Start()
        {
            _eventController = FindObjectOfType<EventController>();
            _eventController.contextMenuEvent.AddListener(ShowContextMenu);
            _menuUI.SetClickAction(OnMenuItemClick);
            _menuUI.Hide();
        }

        private void ShowContextMenu(InteractiveObject obj)
        {
            if (obj == null)
            {
                _menuUI.Hide();
                return;
            }
            List<ContextMenuItemData> itemsData = ScenarioController.GetFilteredContextMenu(obj);
            if (itemsData.Count == 0)
            {
                _menuUI.Hide();
                return;
            }
            _currentObject = obj;
            Vector2 pos = Camera.main.WorldToScreenPoint(obj.transform.position);
            _menuUI.Init(pos, itemsData);
            _menuUI.Show();
        }

        private void OnMenuItemClick(ContextMenuItemData itemData)
        {
            _menuUI.Hide();
            _eventController.DispatchUnityEvent(_eventController.executeActionEvent, itemData.actionName, _currentObject);
        }
    }
}
