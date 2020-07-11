using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSize : MonoBehaviour
{
    SpriteRenderer renderer;
    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        GetVortex();
    }

    public void GetVortex()
    {

        Debug.Log(renderer.sprite.bounds);

    } 
}
