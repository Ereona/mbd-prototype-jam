using UnityEngine;

namespace MurderByDeath.Helpers
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static Singleton<T> Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (Instance != this)
            {
                DestroyImmediate(gameObject);
                return;
            }
        }
    }
}