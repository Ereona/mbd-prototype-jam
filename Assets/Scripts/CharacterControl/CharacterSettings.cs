using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MurderByDeath.CharacterControl
{
    [CreateAssetMenu(menuName = "SO/Settings/CharacterSettings")]
    public class CharacterSettings : ScriptableObject
    {
        public float playerSpeed = 3.0f;
        public float gravityValue = -9.81f;
    }
}
