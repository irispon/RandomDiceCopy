using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceEye : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer sprite;
    [SerializeField]
    string objectPoolKey;
    ObjectPool missileObjectPool;
    FieldOfView view;
    BoardMaster master;
    Vector2 standard;
    Dice dice;
    public void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        missileObjectPool = ObjectPoolManager.GetInstance().Get(objectPoolKey);
  //      Debug.Log(missileObjectPool == null);
        view = GetComponent<FieldOfView>();
        master = BoardMaster.GetInstance();
        standard = master.destination.transform.position;


    }
    public void Init(Dice dice)
    {
      this.dice = dice;
      sprite.sprite = dice.diceStatus.dotSprite;
      StartCoroutine(SearchAndDestroy());
        

    }
    public void ChangeSprite(Sprite sprite)
    {
        this.sprite.sprite = sprite;
    }
    

    IEnumerator SearchAndDestroy()
    {
        Collider2D target= GetTarget();

    
            while (true)
            {

            if (target != null)
            {
                if (target.isActiveAndEnabled)
                {
                    GameObject gameObject = missileObjectPool.GetChild();
                //    Debug.Log(name+"."+gameObject.name);
                    gameObject.transform.position = this.transform.position;
                    gameObject.GetComponent<Missile>().SetMissile(target, 20, sprite.sprite, dice.diceStatus);
                   
                }
                else
                {
                   
                    target = GetTarget();
                    

                }

            }
            else
            {
               target = GetTarget();
            }

            yield return new WaitForSeconds(dice.diceStatus.attackType.attackSpeed);
        }


           

        }

    private Collider2D GetTarget()
    {
        Collider2D[] targets = view.GetAllTargets();
        Collider2D target = null;

     
        System.Array.Sort(targets, (x, y) => AngleDistance(y.transform).CompareTo(AngleDistance(x.transform)));
      
        try
        {

            target = targets[targets.Length-1];
          //  Debug.Log("타겟"+target.name);
        }
        catch (Exception e)
        {

        }

        return target;
    }
    private float AngleDistance(Transform target)
    {
        Vector2 dirToTarget = ((Vector2)target.position - standard).normalized;
        float angle = Vector2.Angle(Vector2.up, dirToTarget);
        float distance = Vector2.Distance(standard, target.position);

        angle = (float)Math.Truncate(angle);
        distance = (float)Math.Truncate(distance) / 1000;
       
       // Debug.Log("transform"+ target.name+"  앵글:" + angle+"거리"+ distance+"결과"+(angle+distance));
      

        return angle +distance;
    }
    }


