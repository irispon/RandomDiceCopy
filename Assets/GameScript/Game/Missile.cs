﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Collider2D box;
    Collider2D target;
    PoolChild poolChild;
    EnemyControler targetObject;
    AttackType damage;

    private void Awake()
    {
       
        box = GetComponent<Collider2D>();
    }
   public void SetMissile(Collider2D target,float speed,Sprite sprite, AttackType damage)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
        this.target = target;
        targetObject = target.GetComponent<EnemyControler>();
        StartCoroutine(Shoot(target, speed));
        this.damage = damage;
    }
    public void Start()
    {
        poolChild = GetComponent<PoolChild>();
    }
    IEnumerator Shoot(Collider2D target,float speed)
    {
        while (target.isActiveAndEnabled)
        {
            
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
          
       
            yield return null;

        }
        poolChild.Turn();

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.name.Equals(target.name))
        {

            targetObject.Damage(damage.damage);
            poolChild.Turn();

        }
    }
}
