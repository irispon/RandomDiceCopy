using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCache : SingletonObject<ExplosionCache>
{
   public Dictionary<OfensiveType, IExplosion> explosions;

    public override void Init()
    {
        explosions = new Dictionary<OfensiveType, IExplosion>();
    }
}
