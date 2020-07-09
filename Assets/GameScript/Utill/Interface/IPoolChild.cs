using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolChild 
{
    void MakeObejctPool(int max,GameObject prefab);
    ObjectPool GetObjectPool();
    void TurnPool();
}
