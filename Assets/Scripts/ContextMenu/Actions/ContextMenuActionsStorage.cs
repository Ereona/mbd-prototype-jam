using MurderByDeath.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MurderByDeath.ContextMenu.Actions
{
    public class ContextMenuActionsStorage : MonoBehaviour
    {
        private Dictionary<string, MenuAction> _actions = new Dictionary<string, MenuAction>();

        private void Start()
        {
            InitActions();
            EventController eventController = FindObjectOfType<EventController>();
            eventController.executeActionEvent.AddListener(ExecuteAction);
        }

        private void InitActions()
        {
            _actions.Add("Take", new TakeAction());
            _actions.Add("Read", new ReadAction());
            _actions.Add("Open", new OpenAction());
        }

        private void ExecuteAction(string name, InteractiveObject obj)
        {
            if (_actions.TryGetValue(name, out MenuAction action))
            {
                action.Execute(obj);
            }
            else
            {
                Debug.LogError(string.Format("MenuAction {0} not found", name));
            }
        }
    }
}
