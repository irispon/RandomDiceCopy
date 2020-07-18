using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwan : MonoBehaviour
{
    [SerializeField]
    ObjectPool enemyObjectPool;
    [SerializeField]
    BoardMaster board;
    [SerializeField]
    Vector2 spwanTime;
   

    Queue<Vector3> destinations; 
    PoolChild child;

    
    public void Start()
    {
        child = GetComponent<PoolChild>();
        destinations = new Queue<Vector3>();
        destinations.Enqueue(board.SecondVertex());
        destinations.Enqueue(board.ThirdVertex());
        destinations.Enqueue(board.FourthVertex());
        StartCoroutine(SpwanMonster());


    }


    public IEnumerator SpwanMonster()
    {
        while (true)
        {
            Enemy enemy = new Enemy();
            enemy.maxHp = Random.Range(60, 200);
            enemy.speed = 5f;
           // Random.Range(0.025f, 0.1f)
            GameObject enemyObject = enemyObjectPool.GetChild();
 
            
            enemyObject.transform.SetParent(transform.parent);
            enemyObject.transform.localPosition= board.FirstVertex();
            enemyObject.transform.localScale = new Vector3(1, 1, 1);

            enemyObject.GetComponent<EnemyControler>().SetEnemy(enemy,destinations,board.FirstVertex());
            yield return new WaitForSeconds(Random.Range(spwanTime.x, spwanTime.y));
        }


    }


}
