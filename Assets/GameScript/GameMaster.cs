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
    [SerializeField]
    GameObject dice;
    [SerializeField]
    List<DiceSlot> emptyDiceSlots;
    List<DiceSlot> pullDiceSlots;

    private int playerMoney;
    private int cost;
    private int throwCostIncrease;
    private int reinForceCostIncrease;
    private List<DiceStatus> deck;
    // Update is called once per frame


    public override void Init()
    {
        playerMoney = 1000;
        cost = 10;
        throwCostIncrease = 20;
        reinForceCostIncrease = 50;
        deck = Deck.GetInstance().decks[DBManager.PlayerID];
        pullDiceSlots = new List<DiceSlot>();
        ChangeGUI();
    }
    void Update()
    {
        
    }

   public void Throw()
    {
        if (playerMoney>=cost)
        {
            RandDice();
            playerMoney -= cost;
            cost += throwCostIncrease;
         
            if (cost >= 120)
            {
                cost = 120;
            }


            ChangeGUI();
        }

    }

    private void RandDice()
    {
       GameObject diceObject= Instantiate(this.dice);
       Dice dice= diceObject.GetComponent<Dice>();
   
        dice.SetDiceStatus(deck[Random.Range(0,deck.Count)]);
        DiceSlot diceSlot = emptyDiceSlots[Random.Range(0, emptyDiceSlots.Count)];
        emptyDiceSlots.Remove(diceSlot);
        pullDiceSlots.Add(diceSlot);
        diceSlot.SetDice(dice);

    }

    public void Reinforce(ref DiceStatus diceStatus)
    {
        if (diceStatus.reinforceCost <= playerMoney)
        {
            playerMoney-= diceStatus.reinforceCost;
            diceStatus.reinforceCost += reinForceCostIncrease;
            diceStatus.reinforce++;
            Debug.Log("강화 성공");
            ChangeGUI();
        }
        
        
    }

    void ChangeGUI()
    {
        costText.text = cost.ToString();
        playerMoneyText.text = playerMoney.ToString();
    }
}
