using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PoolChild : MonoBehaviour
{
    [HideInInspector]public ObjectPool objectPool;

    public void Turn()
    {
      
        objectPool.TurnChild(this);
    }
    public void SetObjectPool(ObjectPool objectPool)
    {
        this.objectPool = objectPool;
    }
    public void OnDisable()
    {

       // objectPool.TurnChild(gameObject);
    }
}
