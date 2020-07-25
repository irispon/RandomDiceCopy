using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : SingletonObject<ObjectPoolManager>
{
    Dictionary<string,ObjectPool> objectPools;

    public override void Init()
   {
        objectPools = new Dictionary<string, ObjectPool>();
       
    //    DontDestroyOnLoad(this);

   }

    public void Join(string key,ObjectPool objectPool)
    {
        objectPools.Add(key, objectPool);
    }

    public ObjectPool Get(string key)
    {
        if (objectPools.ContainsKey(key))
        {
            return objectPools[key];
        }
        else
        {
            Debug.Log("해당 풀이 존재하지 않습니다.");
            return null;

        }

    }
    public void Delete(string key)
    {
        try
        {
            if (objectPools.ContainsKey(key))
            {
                ObjectPool pool = objectPools[key];
                objectPools.Remove(key);
                Destroy(pool);
            }
            else
            {
                Debug.Log("해당 키가 존재하지 않습니다.");
            }


        }
        catch(Exception e)
        {
            Debug.Log(e);
        }


    }

}
