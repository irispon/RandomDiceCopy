using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : SingletonObject<ObjectPool>
{
    [SerializeField]
    GameObject prefab;
    Queue<GameObject> activeObjects;
    Queue<GameObject> deActiveObjects;
    public override void Init()
    {
        activeObjects = new Queue<GameObject>();
        deActiveObjects = new Queue<GameObject>();
        DontDestroyOnLoad(this);
        Instantiates();
    }

    private void Instantiates()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
