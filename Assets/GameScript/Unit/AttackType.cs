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
    public int range;
    public string introduction;
    public Sprite effect;
    public RuntimeAnimatorController animationEffect;

}

public enum OfensiveType
{
    Direct,Explosion,Chain,Buff,Debuff,Poison
}

public enum DamageType
{
    Magic, Physics, Buff
}

public enum Target
{
    Front, Random
}

