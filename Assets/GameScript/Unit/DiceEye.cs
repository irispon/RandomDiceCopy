using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceEye : MonoBehaviour
{

    public SpriteRenderer sprite;

    public void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    public void Init(Dice dice)
    {
        dice = GetComponentInParent<Dice>();
      
      sprite.sprite = dice.diceStatus.dotSprite;

    }
    public void ChangeSprite(Sprite sprite)
    {
        this.sprite.sprite = sprite;
    }
}
