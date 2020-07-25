using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExplosion
{

    void Explode(Collider2D target,BoxCollider2D warhead,AttackType attackType);
    void Turn();

}
