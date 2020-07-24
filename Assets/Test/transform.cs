using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    
        Debug.Log("트랜스폼 position" + gameObject.transform.position);
        Debug.Log("트랜스폼 up" + gameObject.transform.up);
        Debug.Log("트랜스폼 right" + gameObject.transform.right);
        Debug.Log("트랜스폼 forward" + gameObject.transform.forward);
    //    Debug.Log("트랜스폼 forward" + gameObject.transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
