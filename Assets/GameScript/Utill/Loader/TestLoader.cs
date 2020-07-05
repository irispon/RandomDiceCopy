using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TestLoader :Loader
{


    public override string getContext()
    {
        return context;
    }


    public override bool Load()

    {
        Debug.Log("슬립 테스트");
        Thread.Sleep(2000);
        Debug.Log("슬립 테스트2");
        done = true;
        return done;
    }


}
