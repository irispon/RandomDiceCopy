using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonObjectSlave<T>: MonoBehaviour, Initable where T : SingletonObjectSlave<T>
{
    private static Object lockObj = new Object();
    public static T instance { get; private set; }

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


    public void Init()
    {
        instance = null;
        Destroy(gameObject);
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);


        ObjectManager.GetInstance().AddDontSingletoneObject(this);
    }
}
