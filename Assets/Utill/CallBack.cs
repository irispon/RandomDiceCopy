using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBack : MonoBehaviour
{
    public static IEnumerator WaitThenCallback
        (float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback();
    }
}
