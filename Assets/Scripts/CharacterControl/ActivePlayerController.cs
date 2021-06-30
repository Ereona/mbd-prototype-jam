using MurderByDeath.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MurderByDeath.CharacterControl
{
    public class ActivePlayerController : MonoBehaviour
    {
        [SerializeField]
        private Player _activePlayer;
        private EventController _eventController;

        private bool _isMoving;

        public Player ActivePlayer
        {
            get 
            { 
                return _activePlayer;
            }
            set 
            {
                StopMoving();
                _activePlayer = value;
            }
        }

        private void Start()
        {
            _eventController = FindObjectOfType<EventController>();
            _eventController.mouseButtonHoldEvent.AddListener(OnMouseButtonHold);
            _eventController.mouseButtonUpEvent.AddListener(OnMouseButtonUp);
        }

        private void OnMouseButtonHold(Vector3 pos, bool overUI)
        {
            if (!_isMoving && !overUI)
            {
                StartMoving();
            }
            if (_isMoving)
            {
                GoToTarget(pos);
            }
        }

        private void OnMouseButtonUp(Vector3 pos, bool overUI)
        {
            StopMoving();
        }

        private void StartMoving()
        {
            if (_activePlayer != null)
            {
                _isMoving = true;
                _activePlayer.StartMoving();
            }
        }

        private void StopMoving()
        {
            if (_activePlayer != null)
            {
                if (_isMoving)
                {
                    _isMoving = false;
                    _activePlayer.StopMoving();
                }
            }
        }

        private void GoToTarget(Vector3 mousePos)
        {
            if (_activePlayer != null)
            {
                Vector3? target = GetTargetPosition(mousePos);
                if (target.HasValue)
                {
                    _activePlayer.GoToTarget(target.Value);
                }
            }
        }

        private Vector3? GetTargetPosition(Vector3 mousePos)
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit[] raycasts = Physics.RaycastAll(ray, 100);
            foreach (RaycastHit hit in raycasts)
            {
                if (hit.collider != null)
                {
                    Player p = hit.collider.GetComponentInParent<Player>();
                    if (p == null || p != ActivePlayer)
                    {
                        return hit.point;
                    }
                }
            }
            Plane m_Plane;
            m_Plane = new Plane(Vector3.up, Vector3.zero);
            if (m_Plane.Raycast(ray, out float enter))
            {
                Vector3 hitPoint = ray.GetPoint(enter);
                return hitPoint;
            }
            return null;
        }
    }
}
