using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonExplosion : Explosion
{

 
    public override void Explode(BoxCollider2D box,AttackType attackType)
    {
        EnemyControler controler;
       
        Collider2D[] targetsInViewRadius = GetTargets(box.transform, attackType);
        foreach (Collider2D target in targetsInViewRadius)
        {
            try
            {
                controler = target.GetComponent<EnemyControler>();
                controler.Damage(attackType.damage * attackType.diffusion);
               // Debug.Log("피해 대상"+target.name+ "   "+"폭발 피해"+ attackType.damage * attackType.diffusion);
            }
            catch (Exception e)
            {

            }

        }

    }



}
