using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dice : MonoBehaviour,IDrag
{
    [SerializeField]
    public DiceStatus diceStatus;
    protected int diceEye;
    SpriteRenderer sprite;
    // Start is called before the first frame update


    void Awake()
    {
        //tag = diceStatus.diceName;
        sprite = GetComponent<SpriteRenderer>();

      
    }

    public void SetDiceStatus(DiceStatus diceStatus)
    {
        if (sprite == null)
        {
            sprite = GetComponent<SpriteRenderer>();
        }
        this.diceStatus = diceStatus;
       
        sprite.sprite = diceStatus.sprite;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    void LevelUp()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        GameObject[] dices = GameObject.FindGameObjectsWithTag(tag);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       
    }
}
