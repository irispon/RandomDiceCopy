using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBLoader : Loader
{
    public override void Load()
    {
        Debug.Log("DB초기화");

        DataParser parser = new DataParser();
        DBManager manager = DBManager.GetInstance();
        parser.DiceParse();
        parser.DeckParser("Player");




        done = true;
       
    }

    public override void ThreadLoad()
    {
      

    }

    public override bool IsDone()
    {
        return done;
    }

    


}
