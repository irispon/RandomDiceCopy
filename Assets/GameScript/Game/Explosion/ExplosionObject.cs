using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionObject : MonoBehaviour
{
    AttackType type;
    //애니메이션 관련 변수 추가
    IExplosion explosion;
    Collider2D warHead;

    private void OnEnable()
    {
        type = GetComponentInParent<Dice>().diceStatus.attackType;
        explosion = ExplosionCache.GetInstance().explosions[type.ofensiveType];
        warHead = GetComponent<Collider2D>();
    }

    private void OnDisable()
    {
        explosion.Explode(warHead, type);
    }
}
