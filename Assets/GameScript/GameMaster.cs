using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : SingletonObject<GameMaster>
{
    [SerializeField]
    TextMeshProUGUI costText;
    [SerializeField]
    TextMeshProUGUI playerMoneyText;
    private int playerMoney;
    private int cost;
    private int costIncrease;
    private int reinForceIncrease;
    // Update is called once per frame


    public override void Init()
    {
        playerMoney = 100;
        cost = 10;
        costIncrease = 20;
    }
    void Update()
    {
        
    }

    void Throw()
    {
        if (playerMoney>cost)
        {
            playerMoney -= cost;
            if (cost < 120)
            {
                cost += costIncrease;
            }

            ChangeGUI();
        }

    }

    void Reinforce(ref DiceStatus reinforce)
    {

    }

    void ChangeGUI()
    {
        costText.text = playerMoney.ToString();
        playerMoneyText.text = playerMoney.ToString();
    }
}
