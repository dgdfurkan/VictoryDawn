using UnityEngine;

namespace GunduzDev
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static volatile T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)   instance = FindObjectOfType(typeof(T)) as T;
                
                return instance;
            }
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = (T)this; // this as T;
                DontDestroyOnLoad(instance.gameObject);
            }
            else if (instance != null)
            {
                DestroyImmediate(this.gameObject);
            }
        }
    }
}

