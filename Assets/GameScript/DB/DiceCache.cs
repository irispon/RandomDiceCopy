using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCache : SingletonObject<DiceCache>
{
    public Dictionary<string, DiceStatus[]> diceCache{ get; private set; }

    public override void Init()
    {
        diceCache = new Dictionary<string, DiceStatus[]>();
        DontDestroyOnLoad(this);
        base.Init();
    }



}
