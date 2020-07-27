using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class Loader :MonoBehaviour,ILoader
{

    public string context;
    public bool done=false;

    public virtual string GetContext()
    {
        return context;
    }

    public virtual bool IsDone()
    {
        return done;
    }

    public virtual void Load()
    {
        Task load = Task.Run(() =>
        {

            ThreadLoad();

        });


            
    }
    public ILoader GetLoader()
    {

        return this;
    }

    public void Clear()
    {
        done = false;
    }

    public virtual void ThreadLoad()
    {
        

    }
}
