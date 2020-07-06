using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : SingletonObject<Deck>
{
   const string player = "Player";//임시적 처리
   public Dictionary<string, List<DiceStatus>> decks { get; private set; }

    public override void Init()
    {
        decks = new Dictionary<string, List<DiceStatus>>();
        DontDestroyOnLoad(this);
    }
}
