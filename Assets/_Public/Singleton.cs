using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // Check to see if we're about to be destroyed
    private static bool shutDown = false;
    private static T instance;

    /// <summary>
    /// Access singleton instance through this propriety.
    /// </summary>
    public static T Instance
    {
        get
        {
            if (shutDown)
            {
                Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
                    "' already destroyed. Returning null.");
                return null;
            }

            if (instance == null)
            {
                // Search for existing instance.
                instance = (T)FindObjectOfType(typeof(T));

                // Create new instance if one doesn't alreay exist.
                if (instance == null)
                {
                    // Need to create a new GameObject to attach the singleton to.
                    var singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<T>();
                }

                instance.name = typeof(T).ToString() + " (Singleton)";
            }

            return instance;
        }
    }
    public void RegisterInstance()
    {
        // Make instance persistent.
        DontDestroyOnLoad(Instance);
    }

    private void OnApplicationQuit()
    {
        shutDown = true;
    }

    private void OnDestroy()
    {
        shutDown = true;
    }
}