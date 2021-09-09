using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour //스태틱으로 변수하나선언해서 처음만 찾으면 불러와서 쓸수있다 CPU 를 그만큼 덜 쓴다 
{
    private static bool shuttingDown = false;

    private static object locker = new object(); //스레드를 하나만 돌리게 막는다

    private static T instance = null; //T는 아무거나 쓸수있다
    public static T Instance
    {
        get
        {
            if (shuttingDown == true)
            {
                Debug.LogWarning("[Instance] Instance" + typeof(T) + "is already destroyed. Returning null.");
                return null;
            }

            lock (locker)
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
                        DontDestroyOnLoad(instance);
                    }
                }
                return instance;
            }
        }
    }

    private void OnDestroy()
    {
        shuttingDown = true;
    }

    private void OnApplicationQuit()
    {
        shuttingDown = true;
    }
}
