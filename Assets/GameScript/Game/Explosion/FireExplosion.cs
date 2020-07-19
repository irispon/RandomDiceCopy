using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExplosion : Explosion
{
    Collider2D[] enemies;


    public override void Explode(BoxCollider2D box, AttackType attackType)
    {
        enemies = GetTargets(box.transform, attackType);

        try
        {

            float damage = attackType.damage * attackType.diffusion;
            foreach (Collider2D enemy in enemies)
            {
                enemy.GetComponent<EnemyControler>().Damage(damage);


            }
        
      

        }
        catch (Exception e)
        {

        }

    }

}
