using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumUtills 
{

    public static T Parse<T>(string value) where T:System.Enum
    {
        if (!typeof(T).IsEnum)
        {
            throw new ArgumentException("T must be an enumerated type");
        }

        try
        {
            T t;
            t = (T)Enum.Parse(typeof(T), value);
            Debug.Log("EnumParsing:" + t.ToString());
            return t;
        }
        catch (Exception e)
        {

            throw new ArgumentException("parsing false"+e);

        }

  
    }
    
}
