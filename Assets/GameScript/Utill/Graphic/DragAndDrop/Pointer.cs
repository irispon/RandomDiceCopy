using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : SingletonObject<Pointer>
{
    public GameObject pointObject { get; set; }
    public Content startPoint { get; set; }
    public Content endPoint { get; set; }
}
