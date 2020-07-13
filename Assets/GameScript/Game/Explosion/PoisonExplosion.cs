using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonExplosion : Explosion
{
    public override void Explode(Collider2D warhead,AttackType type)
    {

    }

    public override void Join()
    {
        cache.explosions.Add(OfensiveType.Poison, this);
    }


}
