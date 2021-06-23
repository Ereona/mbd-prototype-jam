using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MurderByDeath.CharacterControl
{
    public class CharacterAnimationController : MonoBehaviour
    {
        private Animator _anim;

        private CharacterState _currentState;
        public CharacterState CurrentState
        {
            get
            {
                return _currentState;
            }
            set
            {
                if (_currentState == value)
                {
                    return;
                }
                _currentState = value;
                _anim.Play(GetAnimationByState(value));
            }
        }

        public enum CharacterState
        {
            Idle,
            Walk
        }

        private void Start()
        {
            _anim = GetComponent<Animator>();
        }

        private string GetAnimationByState(CharacterState state)
        {
            switch (state)
            {
                case CharacterState.Idle:
                    return "KayKit Animated Character|Idle";
                case CharacterState.Walk:
                    return "KayKit Animated Character|Walk";
                default:
                    throw new NotImplementedException("Unknown Character State");
            }
        }
    }
}
