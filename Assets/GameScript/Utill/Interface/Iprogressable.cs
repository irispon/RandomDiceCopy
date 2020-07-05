using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Iprogressable 
{
    float progress { get; set; }
    /// <summary>
    /// 프로그레스 진행도를 리턴해줘야합니다.
    /// </summary>
    /// <returns></returns>
    float Progress();


}
