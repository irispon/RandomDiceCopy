using DigitalRuby.LightningBolt;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBoltManager : SingletonObject<LightningBoltManager>
{
    [SerializeField]
    ObjectPool boltPools;
    LightningBoltScript child;
    LightningBoltScript tmpChild;



    public override void Init()
    {
        if (boltPools == null)
        {
            boltPools = GetComponent<ObjectPool>();
        }
    }

    public List<PoolChild> ChainObjects(ICollection<GameObject> objects, Texture material=null,float time =0.5f)
    {
        List<PoolChild> childs = new List<PoolChild>();
        child = boltPools.GetChild().GetComponent<LightningBoltScript>();
        childs.Add(child.GetComponent<PoolChild>());

        if (material != null)
        {
            child.lineRenderer.material.mainTexture = material;
        }

        int count = objects.Count;

        foreach (GameObject gameObject in objects)
        {
            if (count != 0)
            {
                
                if (child.StartObject == null)
                {
                    child.StartObject = gameObject;

                }
                else if (child.EndObject == null)
                {
                    child.EndObject = gameObject;
                }
                else
                {
                    tmpChild = child;
                    child = boltPools.GetChild().GetComponent<LightningBoltScript>();
                    childs.Add(child.GetComponent<PoolChild>());
                    child.StartObject = tmpChild.EndObject;
                    child.EndObject = gameObject;
                }
                count--;
           


            }


        }
        StartCoroutine(Turn(time,childs));
        return childs;
    }

    IEnumerator Turn(float time,List<PoolChild> childs)
    {
        yield return new WaitForSeconds(time);
        foreach(PoolChild child in childs)
        {
        //    Debug.Log("turn");
            child.Turn();
        }

    }


}
