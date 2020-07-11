using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class UpgradeSlot : MonoBehaviour
{
    ImageTextManager manager;
    DiceStatus diceStatus;
    Image image;
    StringBuilder stringBuilder;
    GameMaster master;
    public void Awake()
    {

        manager = GetComponent<ImageTextManager>();
        image = GetComponent<Image>();
        stringBuilder = new StringBuilder();
        master = GameObject.Find("UserBoard").GetComponent<GameMaster>();
    }

    public void SetDiceStatus( DiceStatus diceStatus)
    {
        this.diceStatus = diceStatus;
        diceStatus.reinforce = 0;
        diceStatus.reinforceCost = 100;
        image.sprite = diceStatus.sprite;
        stringBuilder.Append("").Append((diceStatus.reinforce + 1)).Append("Lv");
        manager.texts[0].text = stringBuilder.ToString();
        stringBuilder.Clear();




    }

    public void Change()
    {
        master.Reinforce(ref diceStatus);
        Debug.Log("강화:"+ diceStatus.diceName + "강화도:"+diceStatus.reinforce);
        manager.texts[0].text = stringBuilder.Append("").Append((diceStatus.reinforce + 1)).Append("Lv").ToString();
        manager.texts[1].text = diceStatus.reinforceCost.ToString();
        stringBuilder.Clear();
    }
}
