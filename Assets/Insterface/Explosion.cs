using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Explosion :IExplosion
{


   protected ExplosionCache cache = ExplosionCache.GetInstance();
    // Start is called before the first frame update
    protected Collider2D[] GetTargets(Transform transform,string layer ="Monster")
    {

        return GetTargets(transform, new Vector2(30, 30));
    }
    protected Collider2D[] GetTargets(Transform transform,Vector2 range, string layer = "Monster")
    {

        return Physics2D.OverlapBoxAll(transform.position, range, 360, LayerMaskUtill.Single(layer));
    }
    protected Collider2D GetTarget(Transform transform,string layer = "Monster")
    {
        return Physics2D.OverlapBox(transform.position, new Vector2(1, 1), 360, LayerMaskUtill.Single(layer));
    }

   
    public abstract void Explode(BoxCollider2D warhead, AttackType attackType);

    public virtual void Turn()
    {
       
    }
}
