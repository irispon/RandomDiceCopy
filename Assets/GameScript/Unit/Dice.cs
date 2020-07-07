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


    void Start()
    {
        tag = diceStatus.diceName;
        sprite = GetComponent<SpriteRenderer>();
        try
        {
            sprite.sprite = diceStatus.sprite;
        }
        catch (Exception e)
        {
            Debug.Log("이미지 확인"+e);
        }
      
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
