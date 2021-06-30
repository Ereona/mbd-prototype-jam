using MurderByDeath.ContextMenu;
using UnityEngine;
using UnityEngine.Events;

namespace MurderByDeath.Events
{
    public class EventController : MonoBehaviour
    {
        public UnityEvent<Vector3, bool> mouseButtonDownEvent;
        public UnityEvent<Vector3, bool> mouseButtonHoldEvent;
        public UnityEvent<Vector3, bool> mouseButtonUpEvent;
        public UnityEvent<Vector3, bool> mouseButtonClickEvent;
        public UnityEvent<InteractiveObject> contextMenuEvent;
        public UnityEvent<string, InteractiveObject> executeActionEvent;

        private void Awake()
        {
            if (mouseButtonDownEvent == null)
                mouseButtonDownEvent = new UnityEvent<Vector3, bool>();
            if (mouseButtonHoldEvent == null)
                mouseButtonHoldEvent = new UnityEvent<Vector3, bool>();
            if (mouseButtonUpEvent == null)
                mouseButtonUpEvent = new UnityEvent<Vector3, bool>();
            if (mouseButtonClickEvent == null)
                mouseButtonClickEvent = new UnityEvent<Vector3, bool>();
            if (contextMenuEvent == null)
                contextMenuEvent = new UnityEvent<InteractiveObject>();
            if (executeActionEvent == null)
                executeActionEvent = new UnityEvent<string, InteractiveObject>();
        }

        public void DispatchUnityEvent(UnityEvent _e)
        {
            if(_e != null)
                _e.Invoke();
        }

        public void DispatchUnityEvent<T>(UnityEvent<T> _e, T arg)
        {
            if (_e != null)
                _e.Invoke(arg);
        }

        public void DispatchUnityEvent<T1, T2>(UnityEvent<T1, T2> _e, T1 arg1, T2 arg2)
        {
            if (_e != null)
                _e.Invoke(arg1, arg2);
        }

        private void OnDestroy()
        {
            mouseButtonDownEvent.RemoveAllListeners();
            mouseButtonHoldEvent.RemoveAllListeners();
            mouseButtonUpEvent.RemoveAllListeners();
            mouseButtonClickEvent.RemoveAllListeners();
            contextMenuEvent.RemoveAllListeners();
            executeActionEvent.RemoveAllListeners();
        }
    }
}