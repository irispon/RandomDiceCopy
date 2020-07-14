using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionObject : MonoBehaviour
{

    //애니메이션 관련 변수 추가
    IExplosion explosion;
    BoxCollider2D box;
    public AttackType type;

    public void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }

    public void Explode(AttackType type)
    {
        this.type = type;

        try
        {

            explosion = ExplosionCache.GetInstance().GetExplosion(this.type.ofensiveType);
            explosion.Explode(box, type);
        }
        catch(Exception e)
        {
          Debug.Log("폭발 에러, 부모에 어택 타입이 존재하지 않거나 딕셔너리에 존재하지 않음"+e);
        }

    }


}
