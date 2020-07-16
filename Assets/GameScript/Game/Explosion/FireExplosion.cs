using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExplosion : Explosion
{
    public override void Explode(BoxCollider2D box, AttackType attackType)
    {
        Collider2D[] enemies = GetTargets(box.transform, attackType);


    }


}
