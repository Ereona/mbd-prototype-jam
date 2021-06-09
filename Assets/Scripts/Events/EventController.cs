using UnityEngine;
using UnityEngine.Events;

namespace MurderByDeath.Events
{
    public class EventController : MonoBehaviour
    {
        #region Touch Events Declaration

        public TKPinchRecognizer pinchRecognizer;
        public TKSwipeRecognizer swipeRecognizer;
        public TKDragRecognizer dragRecognizer;
        public TKTapRecognizer tapRecognizer;

        #endregion

        private void Awake()
        {
            #region Touch Events Initialization

            pinchRecognizer = new TKPinchRecognizer();
            swipeRecognizer = new TKSwipeRecognizer();
            dragRecognizer = new TKDragRecognizer();
            tapRecognizer = new TKTapRecognizer();

            TouchKit.addGestureRecognizer(pinchRecognizer);
            TouchKit.addGestureRecognizer(swipeRecognizer);
            TouchKit.addGestureRecognizer(dragRecognizer);
            TouchKit.addGestureRecognizer(tapRecognizer);

            #endregion
        }

        private void OnDestroy()
        {
            TouchKit.removeAllGestureRecognizers();
        }
    }
}