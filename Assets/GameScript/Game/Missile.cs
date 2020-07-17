using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Collider2D box;
    Collider2D target;
    PoolChild poolChild;
    EnemyControler targetObject;
    public AttackType attackType;
    ExplosionObject explosion;
    Animator animator;
    
    private void Awake()
    {
       
        box = GetComponent<BoxCollider2D>();
        explosion = GetComponentInChildren<ExplosionObject>();
        animator = GetComponent<Animator>();
    }
   public void SetMissile(Collider2D target,float speed,Sprite sprite, AttackType damage)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
        this.target = target;
        targetObject = target.GetComponent<EnemyControler>();
        StartCoroutine(Shoot(target, speed));
        this.attackType = damage;

     
    }
    public void Start()
    {
        poolChild = GetComponent<PoolChild>();
    }
    IEnumerator Shoot(Collider2D target,float speed)
    {
        while (target.isActiveAndEnabled)
        {
            
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
          
       
            yield return new WaitForFixedUpdate();

        }
        poolChild.Turn();
        //    animator.SetBool("Explosion", true);



    }
    void OnTriggerEnter2D(Collider2D collision)
    {

    
        if (collision.Equals(target))
        {
          //  Debug.Log(name+"  "+collision.name);
            targetObject.Damage(attackType.damage);
            explosion.Explode(attackType);
        //    animator.SetBool("Explosion", true);
            poolChild.Turn();

        }
    }

    public void Turn()
    {
   //     animator.SetBool("Explosion", false);
        poolChild.Turn();
        //Debug.Log("Turn");
    
    }
    private void OnDisable()
    {


        target = null;
    

    }



}
