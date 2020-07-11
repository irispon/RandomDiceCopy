using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiceSlot : MonoBehaviour
{
   public Dice dice;


    public void SetDice(Dice dice)
    {
        this.dice = dice;
        dice.transform.SetParent(transform);
        dice.transform.localScale = new Vector3(1, 1, 1);
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
    public void Clear()
    {
        
        dice.Clear();
       //오브젝트 풀 도입하자.
    }



}
