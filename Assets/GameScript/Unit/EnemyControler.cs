using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Crowd;

public class EnemyControler : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sprite;
    [SerializeField]
    Enemy enemy;
    PoolChild child;
    [SerializeField]
    TextMeshPro text;
    [SerializeField]
    GameObject crowdControl;

    public Dictionary<OfensiveType, CrowdControl> crowdControls;
    Queue<Vector3> destinations;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(1,1,1);
        crowdControls = new Dictionary<OfensiveType, CrowdControl>();


    }
   


    public IEnumerator MoveTo(Vector3 targetPositon)
    {


   //  Debug.Log("움직임 " + transform.localPosition +"  "+ targetPositon);
      

        for (; Vector3.Distance(transform.localPosition,targetPositon)>0.005;)
        {
         
            transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, targetPositon, enemy.speed);
           // Debug.Log(name + transform.localPosition);
            yield return new WaitForFixedUpdate();
           
        }
        transform.localPosition = targetPositon;
        //Debug.Log(transform.localPosition);
        if (destinations.Count > 0)
        {
           
            StartCoroutine( MoveTo(destinations.Dequeue()));
   
        }
        else
        {

            Turn();

        }
        yield return null;

        
    }


    public void SetEnemy(Enemy enemy,Queue<Vector3> paths,Vector3 positon)
    {
        if (destinations != null)
        {

            destinations.Clear();
         
        }
        StopAllCoroutines();
        //Debug.Log("set"+name);
        transform.localPosition = positon;
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

    public void Damage(float damage)
    {
        enemy.hp -= (int)damage;
        text.text = enemy.hp.ToString();
        if (enemy.hp <=0)
        {
            Turn();
        }
    }
    private void Turn()
    {
        destinations.Clear();
        child.Turn();
    }
    void Start()
    {

        child = GetComponent<PoolChild>();


    }

    public void SideEffect(float time,AttackType type,CrowdControlEffect effect)
    {



        if (!crowdControls.ContainsKey(type.ofensiveType))
        {
            GameObject crowd = Instantiate(crowdControl);
            SizeFitter.FittingContent(crowd, gameObject);
            crowdControls.Add(type.ofensiveType, crowd.GetComponent<CrowdControl>());
            crowdControls[type.ofensiveType].controler = this;
        }
        crowdControls[type.ofensiveType].SetCrowdControl(time, type.effect, effect);
        //   subSprites[0].sprite = sprite;
        //   IEnumerator coroutine =CrowdControl(time, effect);






    }



    private void OnDisable()
    {
        if(destinations != null)
        {
            destinations.Clear();
        }
   
     
    }
}
