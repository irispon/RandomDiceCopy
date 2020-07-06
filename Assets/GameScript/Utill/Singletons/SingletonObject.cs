using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonObject<T> : MonoBehaviour where T:SingletonObject<T>
{
    /// <summary>
    /// T는 상속받는 클래스의 이름을 작성해주시면 됩니다.
    /// </summary>
    public static T instance { get; private set; } = null;
    private static Object lockObj = new Object();


    protected virtual void Awake()
    {
        if(instance == null)
        {
            instance =this as T;
        }
        else
        {
            Destroy(gameObject);
        }
        Init();
      //  DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update

    public static T GetInstance()
    {

        if (instance == null)
        {
            lock (lockObj)
            {
                if (instance == null)
                {

                    GameObject gameObject = new GameObject();
                    instance = gameObject.AddComponent<T>();

                }
            }

        }

        return instance;

    }


    public virtual void Init()
    {

    }
}