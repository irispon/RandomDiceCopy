using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExplosion
{

    void Explode(BoxCollider2D warhead, AttackType type); 

}
