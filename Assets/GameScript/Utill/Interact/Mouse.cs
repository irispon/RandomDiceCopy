using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse 
{
    public static Vector3 GetMousePosition()
    {

        Vector3 positon = Input.mousePosition;
        positon.z = 10f;
        return Camera.main.ScreenToWorldPoint(positon);
    }

    /// <summary>
    /// 마우스 위치 + Vector2
    /// </summary>
    /// <param name="vector"></param>
    /// <returns></returns>
    public static Vector3 CorrectMousePosition(Vector2 vector)
    {
        
        Vector3 position = GetMousePosition();

      //  Debug.Log("변경 전:" +position.x+", "+ position.y);

        position.x = position.x- vector.x;
        position.y = position.y- vector.y;

       // Debug.Log("변경 후: "+position.x + ", " + position.y);

        return position;
    }
}
