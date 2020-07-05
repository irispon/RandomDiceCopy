using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Loader :MonoBehaviour,ILoader
{

    public string context;
    public bool done=false;

    public virtual string getContext()
    {
        return context;
    }

    public virtual bool isDone()
    {
        return done;
    }

    public virtual bool Load()
    {
        done = true;
        return done;
    }
    public ILoader GetLoader()
    {

        return this;
    }

    public void Clear()
    {
        done = false;
    }
}
