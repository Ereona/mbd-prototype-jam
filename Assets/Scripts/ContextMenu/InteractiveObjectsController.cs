using MurderByDeath.CharacterControl;
using MurderByDeath.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MurderByDeath.ContextMenu
{
    public class InteractiveObjectsController : MonoBehaviour
    {
        private EventController _eventController;
        private ActivePlayerController _playerController;
        private float _distanceToInteract = 2f;

        private void Start()
        {
            _eventController = FindObjectOfType<EventController>();
            _eventController.mouseButtonClickEvent.AddListener(OnMouseButtonClick);
            _eventController.mouseButtonHoldEvent.AddListener(OnMouseButtonHold);
            _playerController = FindObjectOfType<ActivePlayerController>();
        }

        private bool CanShowContextMenuForObject(InteractiveObject obj)
        {
            if (_playerController.ActivePlayer == null)
            {
                return false;
            }
            return Vector3.Distance(_playerController.ActivePlayer.transform.position, obj.transform.position) < _distanceToInteract;
        }

        private void OnMouseButtonClick(Vector3 pos, bool overUI)
        {
            if (overUI)
            {
                return;
            }
            InteractiveObject obj = GetClickedObject(pos);
            if (CanShowContextMenuForObject(obj))
            {
                _eventController.DispatchUnityEvent(_eventController.contextMenuEvent, obj);
            }
        }

        private void OnMouseButtonHold(Vector3 pos, bool overUI)
        {
            if (overUI)
            {
                return;
            }
            _eventController.DispatchUnityEvent(_eventController.contextMenuEvent, null);
        }

        private InteractiveObject GetClickedObject(Vector3 mousePos)
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider != null)
                {
                    return hit.collider.GetComponentInParent<InteractiveObject>();
                }
            }
            return null;
        }
    }
}
