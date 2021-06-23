using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MurderByDeath.CharacterControl
{
    public class Player : MonoBehaviour
    {
        public CharacterSettings settings;
        private CharacterController _controller;
        private CharacterAnimationController _animController;
        private Vector3 _playerVelocity;

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
            _animController = GetComponent<CharacterAnimationController>();
        }

        private void Update()
        {
            if (_controller.isGrounded && _playerVelocity.y < 0)
            {
                _playerVelocity.y = 0f;
            }

            _playerVelocity.y += settings.gravityValue * Time.deltaTime;
            _controller.Move(_playerVelocity * Time.deltaTime);
        }

        public void StartMoving()
        {
            _animController.CurrentState = CharacterAnimationController.CharacterState.Walk;
        }

        public void StopMoving()
        {
            _animController.CurrentState = CharacterAnimationController.CharacterState.Idle;
        }

        public void GoToTarget(Vector3 target)
        {
            Vector3 direction = new Vector3(target.x - transform.position.x, 0, target.z - transform.position.z);
            if (direction.sqrMagnitude > 0.01f)
            {
                _controller.Move(direction.normalized * Time.deltaTime * settings.playerSpeed);
                gameObject.transform.forward = direction.normalized;
            }
        }
    }
}
