using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerMaskUtill 
{
   
  public static int Single(string name)
    {

        return (1 << LayerMask.NameToLayer(name));
    }


    public static int Single(int layer)
    {

        return (1 << layer);
    }

    public static int Composit(string[] layers)
    {
        int layerMask=0;
        foreach (string name in layers)
        {
            layerMask +=Single(name);

        }
        return layerMask;
    }

    public static int Composit(int[] layers)
    {
        int layerMask = 0;
        foreach (int layer in layers)
        {
            layerMask += Single(layer);

        }
        return layerMask;
    }

    public static int Composit(LayerMask[] layers)
    {
        int layerMask = 0;
        foreach (LayerMask layer in layers)
        {
            layerMask += layer.value;

        }
        return layerMask;
    }

    public static int Except(string[] names)
    {
        int layerMask = 0;
        foreach(string name in names)
        {
            layerMask = layerMask | (Single(name));

        }

        return ~layerMask;
    }


    public static int Except(int[] layers)
    {
        int layerMask = 0;
        foreach (int layer in layers)
        {
            layerMask = layerMask | (Single(layer));

        }

        return ~layerMask;
    }

    public static int Except(LayerMask[] layers)
    {
        int layerMask = 0;
        foreach (LayerMask layer in layers)
        {
            layerMask = layerMask | layer.value;

        }

        return ~layerMask;
    }

    public static int Except(string layer)
    {
        string[] names = { layer };
        return Except(names);
    }


    public static int Except(int layer)
    {
        int[] layers = { layer };
        return Except(layers);

    }

    public static int Except(LayerMask layer)
    {
        LayerMask[] layers = { layer };
        return Except(layers);

    }

}
