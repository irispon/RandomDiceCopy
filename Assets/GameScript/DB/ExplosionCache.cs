using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCache : Singleton<ExplosionCache>
{
    Dictionary<OfensiveType, IExplosion> explosions;

}
