using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Crowd;

public class IceExplosion : Explosion
{
    public override void Explode(BoxCollider2D box, AttackType attackType)
    {
        EnemyControler controler;

        Collider2D target = GetTarget(box.transform);
        try
        {
            controler = target.GetComponent<EnemyControler>();
            if (attackType.effect != null && controler.isActiveAndEnabled)
            {


                controler.SideEffect(attackType.range, attackType, (controller) =>{ CrowdEffect(controler, attackType);}, (controller)=> { controller.Recover(EnemyStat.speed); });

               

            }

            // Debug.Log("피해 대상"+target.name+ "   "+"폭발 피해"+ attackType.damage * attackType.diffusion);
        }
        catch (Exception e)
        {
            // Debug.Log("오류"+box.name);
        }

    }

    public void CrowdEffect(EnemyControler controler, AttackType attackType)
    {
        controler.Debuff(attackType.diffusion, attackType.range, EnemyStat.speed);
    }
 
}
