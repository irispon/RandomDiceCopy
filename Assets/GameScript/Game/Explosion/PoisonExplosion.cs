using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonExplosion : Explosion
{

 
    public override void Explode(BoxCollider2D box,AttackType attackType)
    {
        EnemyControler controler;
       
        Collider2D target = GetTarget(box.transform);
            try
            {
                controler = target.GetComponent<EnemyControler>();
            if (attackType.effect != null&&controler.isActiveAndEnabled)
            {
            
                 
                controler.SideEffect(attackType.range,attackType , (controller) => {

                    controler.Damage(attackType.diffusion * attackType.damage);
                 
                 });

    

            }

            // Debug.Log("피해 대상"+target.name+ "   "+"폭발 피해"+ attackType.damage * attackType.diffusion);
        }
            catch (Exception e)
            {
               // Debug.Log("오류"+box.name);
            }

        }

    }




