using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Explosion :IExplosion
{
   protected ExplosionCache cache = ExplosionCache.GetInstance();


    public virtual void Awake()
    {
        Join();
    }

    // Start is called before the first frame update
    public abstract void Join();
    public abstract void Explode(Collider2D warhead, AttackType type);

}
