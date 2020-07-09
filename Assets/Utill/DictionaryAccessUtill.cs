using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DictionaryAccessUtill 
{


    public static IEnumerable<TValue> RandomValues<TKey, TValue>(IDictionary<TKey, TValue> dict)
    {
       
        List<TValue> values = Enumerable.ToList(dict.Values);
        int size = dict.Count;
        while (true)
        {
            yield return values[Random.Range(0,size)];
        }
    }


    public static IEnumerable<TKey> RandomKeys<TKey, TValue>(IDictionary<TKey, TValue> dict)
    {

        List<TKey> keys = Enumerable.ToList(dict.Keys);
        int size = dict.Count;
        while (true)
        {
            yield return keys[Random.Range(0, size)];
        }
    }


    public static TValue RandomValue<TKey, TValue>(IDictionary<TKey, TValue> dict)
    {

        List<TValue> values = Enumerable.ToList(dict.Values);
        int size = dict.Count;

        return values[Random.Range(0, size)];

    }


    public static TKey RandomKey<TKey, TValue>(IDictionary<TKey, TValue> dict)
    {

        List<TKey> keys = Enumerable.ToList(dict.Keys);
        int size = dict.Count;
        return keys[Random.Range(0, size)];

    }
}
