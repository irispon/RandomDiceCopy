using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton <T> where T :class,  new()
{

    /*미 완성 new T()로 쓰지 마세요*/
    private static Object lockObj= new Object();
    protected static T instance=null;

 

    public static T GetInstance()
    {
    
            if (instance == null)
          {  
            lock (lockObj)
            {
                Debug.Log("실행되냐1?");
                if (instance == null)
                {

                    instance = new T();
                
                }
            }

        }

        
        return instance;
    }



}
