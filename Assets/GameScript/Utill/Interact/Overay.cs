using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Overay : MonoBehaviour
{

    private Vector3 originScale;
    private Vector3 overScale;
    private bool select = false;
    

    // Start is called before the first frame update
    void Start()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null)
        {
             //   Debug.Log("렉트 트랜스폼");
                originScale = rectTransform.localScale;
                overScale = new Vector3(0.3f, 0.3f, 0f) + rectTransform.localScale;

        }else if (transform != null)
        {
         //   Debug.Log("트랜스폼");
            originScale = transform.localScale;
            overScale = new Vector3(0.3f, 0.3f, 0f) + transform.localScale;

        }

    }



    // Update is called once per frame
    void Update()
    {

   
    }


    
    private void  OnMouseOver()
    {
        //Debug.Log("테스팅");
        transform.localScale = overScale;

    }

    private void OnMouseExit()
    {
        transform.localScale = originScale;

    }

    private void OnMouseDown()
    {
        


    }

    
}
