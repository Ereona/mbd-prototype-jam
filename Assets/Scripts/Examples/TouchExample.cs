using UnityEngine;
using MurderByDeath.Events;

namespace MurderByDeath.Examples
{
    public class TouchExample : MonoBehaviour
    {
        [SerializeField] private EventController _eventControl;

        [SerializeField] private GameObject _eventControlPrefab;

        // Start is called before the first frame update
        void Start()
        {
            if(_eventControl == null)
            {
                GameObject _e = GameObject.FindWithTag("EventController");

                if(_e == null)
                    _e = Instantiate(_eventControlPrefab);
                
                _eventControl = _e.GetComponent<EventController>();
            }
            _eventControl.pinchRecognizer.gestureRecognizedEvent += (Pinch);
            _eventControl.dragRecognizer.gestureRecognizedEvent += (Drag);
            _eventControl.tapRecognizer.gestureRecognizedEvent += (Tap);
            _eventControl.swipeRecognizer.gestureRecognizedEvent += (Swipe);

            //restrict the drag recognizer to the lower left side of the screen
			_eventControl.dragRecognizer.boundaryFrame = new TKRect( 0, 0, Screen.width * 0.5f, Screen.height * 0.5f );

            GetComponent<TouchKit>().autoScaleRectsAndDistances = true;
        }
        private void Drag(TKDragRecognizer _drag)
        {
            Vector2 _dragDirection = _drag.currentPoint - _drag.startPoint;
            Debug.Log(_dragDirection + " IS THE SCREEN SPACE DIRECTION FROM THE START TOUCH POSITION TO THE CURRENT TOUCH POSITION");
        }
        private void Tap(TKTapRecognizer _tap)
        {
            Debug.Log(_tap.touchLocation() + " IS THE SCREEN SPACE TAP POSITION");
        }
        private void Swipe(TKSwipeRecognizer _swipe)
        {
            if(_swipe.completedSwipeDirection == TKSwipeDirection.Left)
            {
                Debug.Log("WAS A LEFT SWIPE");
            }
            else if(_swipe.completedSwipeDirection == TKSwipeDirection.Right)
            {
                Debug.Log("WAS A RIGHT SWIPE");
            }
            else if(_swipe.completedSwipeDirection == TKSwipeDirection.Down)
            {
                Debug.Log("WAS A DOWNWARD SWIPE");
            }
            else if(_swipe.completedSwipeDirection == TKSwipeDirection.Up)
            {
                Debug.Log("WAS A UPWARD SWIPE");
            }
            if(_swipe.completedSwipeDirection == TKSwipeDirection.UpRight)
            {
                Debug.Log("WAS AN UPPER RIGHT SWIPE");
            }
            else if(_swipe.completedSwipeDirection == TKSwipeDirection.DownLeft)
            {
                Debug.Log("WAS AN LOWER LEFT SWIPE");
            }
            else if(_swipe.completedSwipeDirection == TKSwipeDirection.UpLeft)
            {
                Debug.Log("WAS AN UPPER LEFT SWIPE");
            }
            else if(_swipe.completedSwipeDirection == TKSwipeDirection.DownRight)
            {
                Debug.Log("WAS AN LOWER RIGHT SWIPE");
            }
            if(_swipe.completedSwipeDirection == TKSwipeDirection.Horizontal)
            {
                Debug.Log("WAS A HORIZONTAL SWIPE");
            }
            else if(_swipe.completedSwipeDirection == TKSwipeDirection.Vertical)
            {
                Debug.Log("WAS A VERTICAL SWIPE");
            }
            //AND THERE ARE MORE SWIPE OPTIONS. DIAGONAL/CARDINAL, etc..
        }
        private void Pinch(TKPinchRecognizer _pinch)
        {
            Debug.Log(_pinch.accumulatedScale + " IS THE FULL ACCUMULATIVE PINCH SCALE SINCE STARTING THE PINCH GESTURE");
        }
    }
}