using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WList<T> : List<T>
{

    public WList() : base()
    {

    }
    public WList(IEnumerable<T> collection) : base(collection)
    {


    }
    public WList(int capacity):base(capacity)
    {


    }



    public WList<T> Clone()
    {
        WList<T> clone = new WList<T>();
        clone.AddRange(this);
             
        return clone;
    }
}
