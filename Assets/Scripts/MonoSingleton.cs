using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour //����ƽ���� �����ϳ������ؼ� ó���� ã���� �ҷ��ͼ� �����ִ� CPU �� �׸�ŭ �� ���� 
{
    private static bool shuttingDown = false;

    private static object locker = new object(); //�����带 �ϳ��� ������ ���´�

    private static T instance = null; //T�� �ƹ��ų� �����ִ�
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
