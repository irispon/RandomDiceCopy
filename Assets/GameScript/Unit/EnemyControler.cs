using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyControler : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sprite;
    [SerializeField]

    Queue<Vector3> destinations;
    [SerializeField]
    Enemy enemy;
    PoolChild child;
    [SerializeField]
    TextMeshPro text;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        enemy.speed = 0.025f;
        transform.localScale = new Vector3(1,1,1);
  
    }


    public IEnumerator MoveTo(Vector3 targetPositon)
    {


     //   Debug.Log("움직임 " + localPositon +"  "+ targetPositon);
      

        for (; this.transform.localPosition != targetPositon;)
        {
            //Debug.Log("움직임 "+ this.transform.localPosition);
            this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, targetPositon, enemy.speed);
            yield return null;
        }


        if (destinations.Count > 0)
        {
           StartCoroutine( MoveTo(destinations.Dequeue()));
        }
        else
        {

            child.Turn();
            
        }

    }
    public void SetEnemy(Enemy enemy,Queue<Vector3> paths)
    {
        destinations = new Queue<Vector3>(paths);
       // sprite.sprite = enemy.sprite;
        this.enemy = enemy;
        text.text = enemy.maxHp.ToString();
        enemy.hp = enemy.maxHp;
        if (destinations.Count > 0)
        {
            StartCoroutine(MoveTo(destinations.Dequeue()));
        }

    }
    void Start()
    {

        child = GetComponent<PoolChild>();


    }



}
