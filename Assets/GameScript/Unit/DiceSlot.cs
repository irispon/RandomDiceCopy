using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSlot : MonoBehaviour
{
    Dice dice;


    public void SetDice(Dice dice)
    {
        this.dice = dice;
        dice.transform.SetParent(transform);
    }
   public bool IsExist()
    {
        if (dice == null)
        {
            return false;
        }

        return true;
    }

    public ref DiceStatus GetDiceRef()
    {

        return ref dice.diceStatus;
    }
    public DiceStatus GetDiceInfo()
    {

        return dice.diceStatus;
    }


}
