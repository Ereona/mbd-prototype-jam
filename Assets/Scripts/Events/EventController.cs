using UnityEngine;
using UnityEngine.Events;

namespace MurderByDeath.Events
{
    public class EventController : MonoBehaviour
    {
        public UnityEvent myEvent;

        private void Awake()
        {
            if(myEvent == null)
                myEvent = new UnityEvent();
        }

        public void DispatchUnityEvent(UnityEvent _e)
        {
            if(_e != null)
                _e.Invoke();
        }

        private void OnDestroy()
        {
            myEvent.RemoveAllListeners();
        }
    }
}