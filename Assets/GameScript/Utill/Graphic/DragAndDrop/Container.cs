using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : SingletonObject<Container>
{
    
    [HideInInspector] public GameObject content { get; set; }
    [HideInInspector] public SpriteRenderer renderer;
    protected override void Awake()
    {
        base.Awake();
        if(content == null)
        {
            content = new GameObject();
            renderer = content.AddComponent<SpriteRenderer>();
        }
        
       


    }

}
