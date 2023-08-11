using UnityEngine;

namespace Public
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        /// <summary>
        /// Access singleton instance through this propriety.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    // Search for existing instance.
                    //instance = (T)FindObjectOfType(typeof(T));
                    instance = GameObject.FindObjectOfType<T>();

                    // Create new instance if one doesn't alreay exist.
                    if (instance == null)
                    {
                        //Debug.Log("Can't Find Instance");
                        // Need to create a new GameObject to attach the singleton to.
                        var singletonObject = new GameObject();
                        instance = singletonObject.AddComponent<T>();
                        //Debug.Log("Create New Instance");
                    }

                    instance.name = typeof(T).ToString() + " (Singleton)";
                }

                return instance;
            }
        }
        public void RegisterInstance()
        {
            var t = GameObject.FindObjectOfType<T>();
            if (t != null)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(Instance);
            }
        }
    }
}