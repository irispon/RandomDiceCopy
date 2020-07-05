using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMaster 
{
    void Release(ISlave slave);
    void Join(ISlave master);
}
