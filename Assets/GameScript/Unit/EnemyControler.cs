using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sprite;
    [SerializeField]
    List<Transform> paths;
    Queue<Transform> destinations;
    [SerializeField]
    Enemy enemy;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        enemy.speed = 1.5f;
        destinations = new Queue<Transform>(paths);
    }

    public IEnumerator MoveTo(Transform transform)
    {
        Vector3 localPositon = this.transform.localPosition;
        Vector3 targetPositon = transform.localPosition;
        Debug.Log("움직임 " + localPositon +"  "+ targetPositon);
      
        for (; ((localPositon.x != targetPositon.x)&&(localPositon.y!= targetPositon.y));)
        {
            Debug.Log("움직임 "+ localPositon);
            Vector3.MoveTowards(localPositon, targetPositon, enemy.speed);
            yield return null;
        }


        if (destinations.Count > 0)
        {
           StartCoroutine( MoveTo(destinations.Dequeue()));
        }

    }
    void Start()
    {
        if (destinations.Count > 0)
        {
            StartCoroutine(MoveTo(destinations.Dequeue()));
        }
   
    }


}
