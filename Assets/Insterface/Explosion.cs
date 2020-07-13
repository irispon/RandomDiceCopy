using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Explosion :IExplosion
{
    public abstract void Explod();
    public abstract void SetExplosion(AttackType type);
    // Start is called before the first frame update
    public void Join()
    {

    }


}
