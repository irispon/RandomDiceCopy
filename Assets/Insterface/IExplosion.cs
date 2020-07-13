using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExplosion
{

    void Explode(Collider2D warhead, AttackType type); 

}
