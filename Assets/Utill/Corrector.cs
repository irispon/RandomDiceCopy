using System;
using UnityEngine;

public class Corrector
{
    public static Vector3 Correct(Vector3 vector)
    {
        if (vector.x >= 0)
        {
            vector.x = (int)vector.x;
        }
        else
        {
            vector.x = Math.Abs(vector.x);
            vector.x = (int)Math.Ceiling(vector.x);
            vector.x = -vector.x;


        }

        if (vector.y >= 0)
        {
            vector.y = (int)vector.y;
        }
        else
        {
            vector.y = Math.Abs(vector.y);
            vector.y = (int)(Math.Ceiling(vector.y));
            vector.y = -vector.y;
        }


        return vector;
    }
}
