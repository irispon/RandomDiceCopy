using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("Object Pool")]
    [SerializeField]
    PoolChild prefab;
    [SerializeField]
    int max;
    public List<GameObject> activeObjects { get; private set; }
    public Queue<GameObject> deActiveObjects { get; private set; }
    GameObject objectPools;
    string poolName;
    private object lockObject = new object();

    public void Awake()
    {
      poolName = prefab.name + "Pool";
      Debug.Log("풀 초기화"+poolName);
      ObjectPoolManager.GetInstance().Join(poolName, this);
      Init();

    }

    public  void Init()
    {

        activeObjects = new List<GameObject>();
        deActiveObjects = new Queue<GameObject>();
      //  DontDestroyOnLoad(this);
        objectPools = new GameObject(poolName);
        objectPools.transform.SetParent(transform);
        Instantiates();

    }

    public static ObjectPool MakeInstance(string name, GameObject prefab, int max=10)
    {
        
        GameObject gameObject = new GameObject();
        gameObject.AddComponent<ObjectPool>();
        ObjectPool objectPool = gameObject.GetComponent<ObjectPool>();
        ObjectPoolManager.GetInstance().Join(name, objectPool);
        return objectPool;
    }

    private void Instantiates()
    {
      
       

        // 풀링 개수만큼 생성 
        for (int i = 0; i < max; i++)
        {
            GameObject obj = Instantiate(prefab.gameObject, objectPools.transform);
            PoolChild poolChild = obj.GetComponent<PoolChild>();
            poolChild.SetObjectPool(this);
     
            obj.name = prefab.name + i.ToString("00");
            obj.SetActive(false);
            deActiveObjects.Enqueue(obj);
        }





    }

    public GameObject GetChild()
    {
    
        lock (lockObject)
        {

            GameObject obj;
        if (deActiveObjects.Count > 0)
        {
            obj = deActiveObjects.Dequeue();
        }
        else
        {
            obj = Instantiate(prefab.gameObject, objectPools.transform);
            obj.GetComponent<PoolChild>().SetObjectPool(this);
            Debug.Log("생성");
        }


        
        obj.SetActive(true);
         activeObjects.Add(obj);




        return obj;
        }
    }
    public void TurnChild(PoolChild child)
    {
      
        child.gameObject.SetActive(false);
        child.transform.SetParent(objectPools.transform);
       if(!deActiveObjects.Contains(child.gameObject))
        {
            deActiveObjects.Enqueue(child.gameObject);
            activeObjects.Remove(child.gameObject);
        }

     
    }

    public void Clear()
    {
        Destroy(objectPools);
        activeObjects.Clear();
        deActiveObjects.Clear();
        Instantiates();
    }

}
