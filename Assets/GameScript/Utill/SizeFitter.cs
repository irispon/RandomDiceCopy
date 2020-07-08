using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeFitter 
{
 public static void FittingSize(GameObject gameObject)
    {
        Transform transform = gameObject.transform;

        transform.localScale = new Vector3(1, 1, 1);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
        Debug.Log(transform.localPosition);
    }

    public static void FittingContent(GameObject content, GameObject parent)
    {
        content.transform.SetParent(parent.transform);
        content.transform.localPosition = new Vector3(0, content.transform.localPosition.y);
       
    }
}
