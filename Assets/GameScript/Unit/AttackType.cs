using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AttackType 
{
    public OfensiveType ofensiveType;
    public DamageType damageType;
    public Target target;

    public float damage;
    public float attackSpeed;
    public float diffusion;
    public float diffusionSpeed;
    public int range;



}

public enum OfensiveType
{
    Direct,Explosion,Chain,Buff
}

public enum DamageType
{
    Magic, Physics, Buff
}

public enum Target
{
    Front, Random
}

