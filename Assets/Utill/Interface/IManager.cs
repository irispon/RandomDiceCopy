using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManager
{
    List<IObjectInfo> GetDatas();
    GameObject MakeObject(IObjectInfo info);
    GameObject MakeObject(GameObject borad,Transform positon, IObjectInfo info);
    GameObject MakeObject(GameObject borad, Vector3 positon, IObjectInfo info);
    GameObject MakeObject(Transform borad, Vector3 positon, IObjectInfo info);
    GameObject MakeObject(Transform borad, Transform positon, IObjectInfo info);
}
