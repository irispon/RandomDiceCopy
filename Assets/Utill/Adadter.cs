using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adadter<A,B> where A: new() where B: new()
{
    A a;
    B b;
    public void setA(A a)
    {
        a = this.a;
    }
    public void setB(B b)
    {
        b = this.b;

    }


    bool isConnect()
    {


        return false;
    }
}
