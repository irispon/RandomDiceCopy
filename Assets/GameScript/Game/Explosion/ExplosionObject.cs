using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionObject : MonoBehaviour
{

    //애니메이션 관련 변수 추가
    IExplosion explosion;
    BoxCollider2D warHead;

    public void Awake()
    {
        warHead = GetComponent<BoxCollider2D>();
    }

    public void Explode(AttackType type)
    {

        try
        {
            explosion = ExplosionCache.GetInstance().explosions[type.ofensiveType];
            explosion.Explode(warHead, type);
        }
        catch(Exception e)
        {
            Debug.Log("딕셔너리 에러"+e);
        }

    }

}
