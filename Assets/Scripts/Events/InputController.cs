using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MurderByDeath.Events
{
    public class InputController : MonoBehaviour
    {
        public float clickInterval = 0.2f;
        private EventController _eventController;
        private float _mouseDownTime;
        private bool _overUI;

        private void Start()
        {
            _eventController = FindObjectOfType<EventController>();
            Input.multiTouchEnabled = false;
        }

        private void Update()
        {
            bool overUI = IsOverUI();

            if (Input.GetMouseButtonDown(0))
            {
                _mouseDownTime = Time.time;
                _eventController.DispatchUnityEvent(_eventController.mouseButtonDownEvent, Input.mousePosition, overUI);
            }
            else if (Input.GetMouseButton(0))
            {
                if (Time.time - _mouseDownTime > clickInterval)
                {
                    _eventController.DispatchUnityEvent(_eventController.mouseButtonHoldEvent, Input.mousePosition, overUI);
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _eventController.DispatchUnityEvent(_eventController.mouseButtonUpEvent, Input.mousePosition, overUI);
                if (Time.time - _mouseDownTime <= clickInterval)
                {
                    _eventController.DispatchUnityEvent(_eventController.mouseButtonClickEvent, Input.mousePosition, overUI);
                }
            }
        }

        private bool IsOverUI()
        {
            // check mouse
            if (EventSystem.current == null)
            {
                return false;
            }
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return true;
            }

            //check touch
            if (Input.touchCount > 0)
            {
                UnityEngine.Touch touch = Input.touches[0];
                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    _overUI = EventSystem.current.IsPointerOverGameObject(touch.fingerId);
                    return _overUI;
                }
                else
                {
                    return _overUI;
                }

            }

            return false;
        }
    }
}
