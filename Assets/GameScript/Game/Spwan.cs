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
    Vector2 spwanTime, enemyHp, enemySpeed;
    bool boss = false;

    Queue<Vector3> destinations; 
    PoolChild child;
    /// <summary>
    /// 적 스텟 범위
    /// </summary>


    

    public void Start()
    {
        child = GetComponent<PoolChild>();
        destinations = new Queue<Vector3>();
        destinations.Enqueue(board.SecondVertex());
        destinations.Enqueue(board.ThirdVertex());
        destinations.Enqueue(board.FourthVertex());
        StageManager.GetInstance().Join(this);
        enemyHp = new Vector2(60, 200);
        enemySpeed = new Vector2(3f, 5f);
        StartCoroutine(SpwanMonster());


    }


    public IEnumerator SpwanMonster()
    {
        Debug.Log("start spwan"+boss);
        while (!boss)
        {
          //  Debug.Log("spwan");
            Enemy enemy = new Enemy();
            enemy.maxHp = (int)Random.Range(enemyHp.x, enemyHp.y);
            enemy.speed = Random.Range(enemySpeed.x, enemySpeed.y);
            enemy.speed =(float)System.Math.Truncate(enemy.speed * 10 / 10);
           // Random.Range(0.025f, 0.1f)
            GameObject enemyObject = enemyObjectPool.GetChild();
 
            
            enemyObject.transform.SetParent(transform.parent);
            enemyObject.transform.localPosition= board.FirstVertex();
            enemyObject.transform.localScale = new Vector3(1, 1, 1);

            enemyObject.GetComponent<EnemyControler>().SetEnemy(enemy,destinations,board.FirstVertex());
            yield return new WaitForSeconds(Random.Range(spwanTime.x, spwanTime.y));
        }


    }

    public void SetEnemy(int level)
    {
        enemyHp += new Vector2(10 * level, 20 * level);
        enemySpeed += new Vector2(0, 0.05f * level);
    
    }
    public void SpwanBoss()
    {
        Debug.Log("보스 생성");
        boss = true;
    }


}
