using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MurderByDeath.Events
{
    public class InputControler : MonoBehaviour
    {
        private EventController _eventController;

        private void Start()
        {
            _eventController = FindObjectOfType<EventController>();
            Input.multiTouchEnabled = false;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _eventController.DispatchUnityEvent(_eventController.startMovingEvent);
            }
            else if (Input.GetMouseButton(0))
            {
                Vector3? target = GetTargetPosition();
                if (target.HasValue)
                {
                    _eventController.DispatchUnityEvent(_eventController.goToTargetEvent, target.Value);
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _eventController.DispatchUnityEvent(_eventController.stopMovingEvent);
            }
        }

        private Vector3? GetTargetPosition()
        {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            Plane m_Plane;
            m_Plane = new Plane(Vector3.up, Vector3.zero);
            float enter = 0.0f;
            if (m_Plane.Raycast(ray, out enter))
            {
                Vector3 hitPoint = ray.GetPoint(enter);
                return hitPoint;
            }
            return null;
        }
    }
}
