using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPControler : MonoBehaviour
{
    [SerializeField]
    GameObject hpObj;
    float hitPoint;
    List<GameObject> hpObjects;
    List<GameObject> unFillHP;
    // Start is called before the first frame update

    public void Awake()
    {
        hpObjects = new List<GameObject>();
        unFillHP = new List<GameObject>();
    }
    public void SetHP(float hitPoint)
    {
        this.hitPoint = hitPoint;
        GameObject hp=null;
        for (int i = 0; i < hitPoint; i++)
        {
           hp = Instantiate(hpObj);
           
            hpObjects.Add(hp);
            SizeFitter.FittingContent(hp, gameObject);
            SizeFitter.FittingSize(hp);
        }
       
       float residualPoint = hitPoint - (float)Math.Truncate(hitPoint);
      
        if (residualPoint > 0)
        {
            hp = Instantiate(hpObj);
            hp.GetComponent<Image>().fillAmount = residualPoint;
            hpObjects.Add(hp);
            SizeFitter.FittingContent(hp, gameObject);
            SizeFitter.FittingSize(hp);
        }


    }
    public void GetDamage(float damage)
    {
     //   Debug.Log(damage);
     
        hitPoint -= damage;
        float remainHP =hitPoint;
      //  Debug.Log(hitPoint);
        if (hitPoint <= 0)
        {
            //이 부분은 리펙토링 해야함. 리턴 값을 넘겨주던 콜백을 하던 해야함.
            MainCamera.GetInstance().canvas.sortingLayerName = "UI";
            Debug.Log("GameOver");
            StageManager.GetInstance().Out.SetActive(true);

            Time.timeScale = 0;
        }
        foreach (GameObject hp in hpObjects)
        {
            Filling(ref remainHP, hp);
        }


        
    }
    void Filling(ref float hitPoint,GameObject hp)
    {
      Image hpImage=  hp.GetComponent<Image>();
        if (hitPoint > 1)
        {
            hpImage.fillAmount = 1;
            hitPoint -= 1;

        }
        else if(hitPoint>0)
        {
            hpImage.fillAmount = hitPoint;
            hitPoint = 0;

        }
        else
        {
            hpImage.fillAmount = 0;
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
