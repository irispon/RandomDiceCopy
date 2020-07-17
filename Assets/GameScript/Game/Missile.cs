﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Collider2D box;
    Collider2D target;
    PoolChild poolChild;
    EnemyControler targetObject;
    public AttackType attackType;
    ExplosionObject explosion;
    Animator animator;
    bool hasAnimation;
    
    private void Awake()
    {
       
        box = GetComponent<BoxCollider2D>();
        explosion = GetComponentInChildren<ExplosionObject>();
        animator = GetComponent<Animator>();
    }
   public void SetMissile(Collider2D target,float speed,Sprite sprite, AttackType damage,RuntimeAnimatorController controller =null)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
        this.target = target;
        targetObject = target.GetComponent<EnemyControler>();
        StartCoroutine(Shoot(target, speed));
        this.attackType = damage;
        if(controller == null)
        {
            animator.runtimeAnimatorController = null;
            hasAnimation = false;
        }
        else
        {
            animator.runtimeAnimatorController = controller;
            hasAnimation = true;
        }
     //   Debug.Log("탄 설정");

    }
    public void Start()
    {
        poolChild = GetComponent<PoolChild>();
    }
    IEnumerator Shoot(Collider2D target,float speed)
    {
        while (target.isActiveAndEnabled)
        {
            
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed* Time.deltaTime);
          
       
            yield return new WaitForFixedUpdate();

        }

        //    animator.SetBool("Explosion", true);
        if (hasAnimation)
        {
            animator.SetTrigger("Explosion");
        }
        else
        {
            Turn();
        }
      
        yield return new WaitForFixedUpdate();

    }
    void OnTriggerEnter2D(Collider2D collision)
    {

    
        if (collision.Equals(target))
        {
          //  Debug.Log(name+"  "+collision.name);
            targetObject.Damage(attackType.damage);
            explosion.Explode(attackType);
            if (hasAnimation)
            {
                animator.SetTrigger("Explosion");

            }
            else
            {
                Turn();
            }
        


        }
    }

    public void Turn()
    {
        //     animator.SetBool("Explosion", false);
    //    Debug.Log("턴" + name);
        poolChild.Turn();
        //Debug.Log("Turn");

    }
    private void OnDisable()
    {


        target = null;
    

    }



}
