using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PoolChild : MonoBehaviour
{
    public string parentKey;

    public void Turn()
    {
        ObjectPool objectPool = ObjectPoolManager.GetInstance().Get(parentKey);
        objectPool.TurnChild(gameObject);
    }
    public void OnDisable()
    {
     ObjectPool objectPool=   ObjectPoolManager.GetInstance().Get(parentKey);
        objectPool.TurnChild(gameObject);
    }
}
