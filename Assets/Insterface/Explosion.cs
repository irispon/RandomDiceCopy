using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Explosion :IExplosion
{
   protected ExplosionCache cache = ExplosionCache.GetInstance();
    // Start is called before the first frame update
    protected Collider2D[] GetTargets(Transform transform,AttackType attackType)
    {
        return Physics2D.OverlapBoxAll(transform.position, new Vector2(attackType.range, attackType.range), 360, LayerMaskUtill.Single("Monster"));
    }
    protected Collider2D[] GetTargets(Transform transform, AttackType attackType,string layer)
    {
        return Physics2D.OverlapBoxAll(transform.position, new Vector2(attackType.range, attackType.range), 360, LayerMaskUtill.Single(layer));
    }
    public abstract void Explode(BoxCollider2D box,AttackType attackType);

}
