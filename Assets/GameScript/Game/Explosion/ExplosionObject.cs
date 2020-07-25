using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionObject : MonoBehaviour
{

    //애니메이션 관련 변수 추가
    IExplosion explosion;
    BoxCollider2D warHead;
    Animator animator;
    public AttackType type;
    Transform parent;
    SpriteRenderer sprite;

    public void Awake()
    {
        warHead = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        parent = transform.parent;
        sprite = GetComponent<SpriteRenderer>();
    }
    public void SetExplode(AttackType type)
    {

   
        this.type = type;
   
        animator.runtimeAnimatorController = type.animationEffect;
        sprite.sprite = null;
    }

    public void Explode(Collider2D target,AttackType type)
    {
        try
        {
            sprite.sprite = null;
            explosion = ExplosionCache.GetInstance().GetExplosion(this.type.ofensiveType);
            if (explosion != null)
            {
                explosion.Explode(target,warHead, type);
                if (animator.runtimeAnimatorController != null)
                {
                    //Debug.Log("?");
                    animator.SetTrigger("Explosion");
                }
            }

           
        }
        catch(Exception e)
        {
          Debug.Log("  "+e);
        }

    }

    public void Turn() {
        sprite.sprite = null;
        animator.runtimeAnimatorController = null;
       // parent.GetComponent<Missile>().Turn();
    }

}
