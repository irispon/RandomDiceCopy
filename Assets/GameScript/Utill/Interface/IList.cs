using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IList<T>
{
    void Bond(T t);
    void Remove();
    void ChangeList();
}
