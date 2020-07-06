using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBLoader : Loader
{
    public override bool Load()
    {
        Debug.Log("DB초기화");

        DBManager manager = DBManager.GetInstance();

        
        


        done = true;
        return done;
    }

  
    public override bool isDone()
    {
        return done;
    }
}
