using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class WDictionary<TKey, TValue> : Dictionary<TKey, TValue>
{


    public WDictionary():base()
     {
     }

    public WDictionary(IDictionary<TKey, TValue> dictionary):base(dictionary)
    {

    }
    public WDictionary(IEqualityComparer<TKey> comparer):base(comparer)
    {


    }
    public WDictionary(int capacity):base(capacity)
    {


    }
    public WDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer):base(dictionary,comparer)
    {


    }
    public WDictionary(int capacity, IEqualityComparer<TKey> comparer):base(capacity,comparer)
    {


    }
    protected WDictionary(SerializationInfo info, StreamingContext context):base(info,context)
    {
        

    }

    public WDictionary<TKey,TValue> Clone()
    {

        return new WDictionary<TKey, TValue>(this);
    }

    /// <summary>
    /// 중복되는 키는 덮어씁니다.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public new void Add(TKey key,TValue value)
    {


        if (ContainsKey(key))
        {
            Debug.Log("키 중복! 삭제 되어집니다.");
            Remove(key);
        }

        base.Add(key,value);
    }

}
