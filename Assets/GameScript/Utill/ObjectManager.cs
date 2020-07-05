using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : Singleton<ObjectManager>
{
    List<Initable> dontDestroyObjects;
    
    public ObjectManager()
    {
        dontDestroyObjects = new List<Initable>();
    }

    public void AddDontSingletoneObject(Initable gameObject)
    {
        Debug.Log("오브젝트 등록");
        dontDestroyObjects.Add(gameObject);

    }

    public void DestoryAll()
    {
        foreach (Initable gameObject in dontDestroyObjects)
        {
            Debug.Log("오브젝트 파괴");
            gameObject.Init();

        }
        dontDestroyObjects.Clear();
        GC.Collect();
    }
}
