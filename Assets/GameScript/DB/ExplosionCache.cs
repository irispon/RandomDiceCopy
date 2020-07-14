using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCache : SingletonObject<ExplosionCache>
{
   public Dictionary<OfensiveType, IExplosion> explosions;

    public override void Init()
    {
        explosions = new Dictionary<OfensiveType, IExplosion>();
        DontDestroyOnLoad(this);
    }

    public IExplosion GetExplosion(OfensiveType type)
    {
        IExplosion explosion=null;
        if (explosions.ContainsKey(type))
        {

            explosion = explosions[type];
        }
        else
        {
            switch (type)
            {
                case OfensiveType.Buff:
                    explosion = new PoisonExplosion();
                    break;
                case OfensiveType.Chain:
                    explosion = new PoisonExplosion();
                    break;
                case OfensiveType.Debuff:
                    explosion = new PoisonExplosion();
                    break;
                case OfensiveType.Direct:
                    explosion = new PoisonExplosion();
                    break;
                case OfensiveType.Explosion:
                    explosion = new PoisonExplosion();
                    break;
                case OfensiveType.Poison:
                    explosion = new PoisonExplosion();
                    break;
            }

            explosions.Add(type, explosion);
        }

        return explosion;
    }
}
