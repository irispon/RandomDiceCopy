using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy 
{
    public int maxHp;
    public int hp;
    public float speed;
    public Sprite sprite;
    public bool isBoss=false;

    public Enemy Clone()
    {

        return (Enemy)MemberwiseClone();
    }

}
public enum EnemyStat
{
    speed
}