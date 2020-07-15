using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DiceStatus :IObjectInfo
{
    public AttackType attackType;
    public string diceName;
    public int reinforce=0;
    public int reinforceCost;
    public string describe;
    public Sprite sprite;
    public Sprite dotSprite;
    

    public string GetName()
    {
        return diceName;
    }
    /// <summary>
    /// 사용되지 않는 인터페이스 입니다.
    /// </summary>
    /// <returns></returns>
    public IManager GetParent()
    {
        
        return null;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }

    public string GetUqName()
    {
        return diceName;
    }
}

