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

    Dice dice;
    public void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        missileObjectPool = ObjectPoolManager.GetInstance().Get(objectPoolKey);
  //      Debug.Log(missileObjectPool == null);
        view = GetComponent<FieldOfView>();
        

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

           Collider2D target = view.GetTarget();
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
                   
                    target = view.GetTarget();
                    

                }

            }
            else
            {
               target = view.GetTarget();
            }

            yield return new WaitForSeconds(dice.diceStatus.attackType.attackSpeed);
        }


           

        }

    }
