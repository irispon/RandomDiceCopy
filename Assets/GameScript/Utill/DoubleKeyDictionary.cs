using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoubleKeyDictionary<K1,K2,Value>:Dictionary<K1,WDictionary<K2,Value>>
{

    public DoubleKeyDictionary() : base()
    {

    }

    public DoubleKeyDictionary(DoubleKeyDictionary<K1,K2,Value> dictionary):base(dictionary)
    {
        
            
    }

    public Value this[K1 key1,K2 key2]
    {
        get
        {
            if (!ContainsKey(key1) || !this[key1].ContainsKey(key2))
                throw new ArgumentOutOfRangeException();
            return base[key1][key2];
        }
        set
        {
            Add(key1, key2, value);
        }

    }


    public void Add(K1 key1,K2 key2, Value value)
    {

        if (!ContainsKey(key1))
        {
            Debug.Log("key1 페어 생성"+key1);
            Add(key1, new WDictionary<K2, Value>());
           
        }
        Debug.Log("key2,value 등록: " +  key2+" " + value);
        try
        {
            this[key1].Add(key2, value);
        }
        catch (Exception e)
        {
            Debug.Log("error 로그 :"+this[key1][key2]);
        }
   

    }

    

    public new IEnumerable<Value> Values
    {
        get
        {
            return from baseDict in base.Values
                   from baseKey in baseDict.Keys
                   select baseDict[baseKey];
        }
    }


    public void Remove(K1 key1,K2 key2)
    {
        this[key1].Remove(key2);

    }

    public bool ContainsKey(K1 key1, K2 key2)
    {
        return base.ContainsKey(key1) && this[key1].ContainsKey(key2);
    }


    public DoubleKeyDictionary<K1,K2,Value> Clone()
    {

        DoubleKeyDictionary<K1, K2, Value> clone = new DoubleKeyDictionary<K1, K2, Value>();
        foreach (K1 key in base.Keys)
        {
            clone.Add(key, this[key].Clone());


        }
        return clone;
    }

}
