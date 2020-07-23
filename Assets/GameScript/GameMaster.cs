using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster:MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI costText;
    [SerializeField]
    TextMeshProUGUI playerMoneyText;
    [SerializeField]
    GameObject dice;
    [SerializeField]
    public List<DiceSlot> emptyDiceSlots;
    [SerializeField]
    ObjectPool dicePool;
    [HideInInspector]public List<DiceSlot> pullDiceSlots;

    private int playerMoney;
    private int cost;
    private int throwCostIncrease;
    private int reinForceCostIncrease;
    private List<DiceStatus> deck;
    

    // Update is called once per frame


    public void Awake()
    {
      
        playerMoney = 3000;
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
        if (emptyDiceSlots.Count>0)
        {
            if (playerMoney >= cost)
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


    }

    private Dice RandDice()
    {
        GameObject diceObject = dicePool.GetChild();
       Dice dice= diceObject.GetComponent<Dice>();
   
        dice.SetDiceStatus(deck[Random.Range(0,deck.Count)]);
        DiceSlot diceSlot = emptyDiceSlots[Random.Range(0, emptyDiceSlots.Count)];
        emptyDiceSlots.Remove(diceSlot);
        pullDiceSlots.Add(diceSlot);
        diceSlot.SetDice(dice);

        return dice;

    }

    public void SynthesisDice(GameObject from,GameObject to)
    {
        Debug.Log("합성"+from.name+ to.name);
        DiceSlot fromSlot = from.GetComponentInParent<DiceSlot>();
        DiceSlot toSlot = to.GetComponentInParent<DiceSlot>();

        Debug.Log(fromSlot.name);
        Debug.Log(toSlot.name);

        fromSlot.Clear();

        emptyDiceSlots.Add(fromSlot);
        pullDiceSlots.Remove(fromSlot);
        //빈 공간 관리

        toSlot.dice.diceEye++;//목표 다이스 눈 증가
        toSlot.dice.SetDiceStatus(deck[Random.Range(0, deck.Count)]);


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

    public void AddMoeny(int money)
    {
        playerMoney += money;
        playerMoneyText.text = playerMoney.ToString();
    }
}
