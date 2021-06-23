using MurderByDeath.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MurderByDeath.CharacterControl
{
    public class ActivePlayerController : MonoBehaviour
    {
        public Player activePlayer;
        private EventController _eventController;

        private void Start()
        {
            _eventController = FindObjectOfType<EventController>();
            _eventController.startMovingEvent.AddListener(StartMoving);
            _eventController.stopMovingEvent.AddListener(StopMoving);
            _eventController.goToTargetEvent.AddListener(GoToTarget);
        }

        private void StartMoving()
        {
            if (activePlayer != null)
            {
                activePlayer.StartMoving();
            }
        }

        private void StopMoving()
        {
            if (activePlayer != null)
            {
                activePlayer.StopMoving();
            }
        }

        private void GoToTarget(Vector3 target)
        {
            if (activePlayer != null)
            {
                activePlayer.GoToTarget(target);
            }
        }
    }
}
