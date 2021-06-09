using UnityEngine;
using UnityEngine.Events;

namespace MurderByDeath.Events
{
    public class EventController : MonoBehaviour
    {
        [HideInInspector] public UnityEvent mapLoadedEvent;

        private void Awake()
        {
            if(mapLoadedEvent == null)
                mapLoadedEvent = new UnityEvent();
        }

        public void FireUnityEvent(UnityEvent _event)
        {
            if(_event != null)
                _event.Invoke();
        }

        private void OnDisable()
        {
            mapLoadedEvent.RemoveAllListeners();
        }
    }
}