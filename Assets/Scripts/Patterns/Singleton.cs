using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunduzDev
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    Debug.Log(instance);
                    instance = FindObjectOfType<T>();
                    Debug.Log(instance);
                    if (instance == null)
                    {
                        Debug.Log(instance);
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        instance = obj.AddComponent<T>();

                        DontDestroyOnLoad(instance.gameObject);
                    }
                }
                return instance;
            }
        }
    }
}
