using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectInfo 
{
    string GetName();
    string GetUqName();
    Sprite GetSprite();
    IManager GetParent();

}
