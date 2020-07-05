using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : SingletonObject<Container>
{
    
    [HideInInspector] public GameObject content { get; set; }

    protected override void Awake()
    {
        base.Awake();
        content = null;

    }

}
