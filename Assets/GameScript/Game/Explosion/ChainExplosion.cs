using DigitalRuby.LightningBolt;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ChainExplosion : Explosion
{
    readonly List<GameObject> gameObjects = new List<GameObject>();
    readonly List<EnemyControler> controlers = new List<EnemyControler>();
  
    public override void Explode(BoxCollider2D warhead, AttackType attackType)
    {
 
        Collider2D[] targets = GetTargets(warhead.transform);
        Vector2 warheadPositon = warhead.transform.position;
        System.Array.Sort(targets, (x, y) =>Vector2.Distance(warheadPositon, x.transform.position).CompareTo(Vector2.Distance(warheadPositon, y.transform.position)));
        gameObjects.Clear();
        controlers.Clear();
        int range;
        //Debug.Log(warhead);
        if (targets.Length>=attackType.range)
        {
            range = attackType.range;

        }
        else
        {

            range = targets.Length;
        }
        for (int i = 0; i < range; i++)
        {
            
            gameObjects.Add(targets[i].gameObject);
            controlers.Add(targets[i].GetComponent<EnemyControler>());
          
        }
        List<PoolChild> childs = LightningBoltManager.GetInstance().ChainObjects(gameObjects);


        foreach (EnemyControler controler in controlers)
        {
            controler.Damage(attackType.damage * attackType.diffusion, Color.yellow);
            controler.SideEffect(0.25f, attackType, (enemyControler) => {});

        }





    }





}
