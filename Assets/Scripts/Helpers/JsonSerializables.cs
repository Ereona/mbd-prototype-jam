using System;
using UnityEngine;

namespace MurderByDeath.Helpers
{
    [Serializable]
    public struct Vector3Json 
    {
        public float x;
        public float y;
        public float z;

        public Vector3Json(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3Json(Vector3 _v)
        {
            x = _v.x;
            y = _v.y;
            z = _v.z;
        }
    }
}