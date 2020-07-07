using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("Object Pool")]
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    int max;
    public Queue<GameObject> activeObjects { get; private set; }
    public Queue<GameObject> deActiveObjects { get; private set; }
    GameObject objectPools;



    public void Awake()
    {
        ObjectPoolManager.GetInstance().Join(name, this);
        Init();

    }

    public  void Init()
    {
        activeObjects = new Queue<GameObject>();
        deActiveObjects = new Queue<GameObject>();
      //  DontDestroyOnLoad(this);
        objectPools = new GameObject(name);
        Instantiates();

    }

    public static ObjectPool MakeInstance(string name,int max=10 )
    {
        GameObject gameObject = new GameObject();
        gameObject.AddComponent<ObjectPool>();
        ObjectPool objectPool = gameObject.GetComponent<ObjectPool>();
        ObjectPoolManager.GetInstance().Join(name, objectPool);
        return objectPool;
    }

    private void Instantiates()
    {
        // 총알을 생성해 child화 할 parent 게임오브젝트 생성(하이러키 뷰에서 관리하기 용이하도록)
       

        // 풀링 개수만큼 총알 생성 
        for (int i = 0; i < max; i++)
        {
            GameObject obj = Instantiate<GameObject>(prefab, objectPools.transform);
            name = prefab.name + i.ToString("00");
            obj.SetActive(false);
          //  deActiveObjects.Enqueue(obj);
        }





    }

    public GameObject GetChild()
    {
        GameObject obj;

        if (deActiveObjects.Count > 0)
        {
            obj = deActiveObjects.Dequeue();
        }
        else
        {
            obj = Instantiate(prefab, objectPools.transform);
        }

        obj.SetActive(true);
        activeObjects.Enqueue(obj);

        return obj;
    }
    public void TurnChild(GameObject gameObject)
    {
        gameObject.SetActive(false);
        deActiveObjects.Enqueue(gameObject);
    }

    public void Clear()
    {
        Destroy(objectPools);
        activeObjects.Clear();
        deActiveObjects.Clear();
        objectPools = new GameObject();
    }

}
