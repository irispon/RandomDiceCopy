using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Animation animation = GetComponent<Animation>();
        animation.Play();
    }


}
