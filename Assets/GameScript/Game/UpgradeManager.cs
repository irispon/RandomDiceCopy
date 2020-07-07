using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    DiceSlotPuncher puncher;
    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {
        puncher = GetComponent<DiceSlotPuncher>();
        try
        {
            List<DiceStatus> decks = Deck.GetInstance().decks["Player"];

            int i = 0;
            foreach (GameObject gameObject in puncher.diceSlots.Values)
            {

                UpgradeSlot slot = gameObject.GetComponent<UpgradeSlot>();

                slot.SetDiceStatus(decks[i]);
                i++;
            }
        }

        catch (Exception e)
        {
            Debug.Log("에러" + e);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
