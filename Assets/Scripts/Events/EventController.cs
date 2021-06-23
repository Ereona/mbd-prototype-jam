using UnityEngine;
using UnityEngine.Events;

namespace MurderByDeath.Events
{
    public class EventController : MonoBehaviour
    {
        public UnityEvent startMovingEvent;
        public UnityEvent stopMovingEvent;
        public UnityEvent<Vector3> goToTargetEvent;

        private void Awake()
        {
            if (startMovingEvent == null)
                startMovingEvent = new UnityEvent();
            if (stopMovingEvent == null)
                stopMovingEvent = new UnityEvent();
            if (goToTargetEvent == null)
                goToTargetEvent = new UnityEvent<Vector3>();
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

        private void OnDestroy()
        {
            startMovingEvent.RemoveAllListeners();
            stopMovingEvent.RemoveAllListeners();
            goToTargetEvent.RemoveAllListeners();
        }
    }
}