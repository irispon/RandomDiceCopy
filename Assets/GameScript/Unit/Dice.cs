using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dice : MonoBehaviour, IDrag, IDrop
{
    [SerializeField]
    public DiceStatus diceStatus;
    [SerializeField]
    public PoolChild child;
    protected int diceEye;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    Container container;
  //  ObjectPool objectPool;

    void Awake()
    {
        child = GetComponent<PoolChild>();
        //tag = diceStatus.diceName;
        sprite = GetComponent<SpriteRenderer>();
        name = nameof(Dice);
        container = Container.GetInstance();
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
        Debug.Log("테스트");
        container.content.SetActive(true);
        container.renderer.sprite = diceStatus.GetSprite();
        container.renderer.sortingLayerName = Layer.UI.ToString();
        container.content.transform.position = Mouse.GetMousePosition();
        GameObject[] dices = GameObject.FindGameObjectsWithTag(tag);


    }

    public void OnDrag(PointerEventData eventData)
    {

        //Debug.Log("드래깅");
        //  correctVector = renderer.size/2;
        container.content.transform.position = Mouse.GetMousePosition();

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        container.content.SetActive(false);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("테스트");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       // sprite.color = new Color32(255, 255, 255, 100);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //sprite.color = new Color32(255, 255, 255, 100);
    }
    public void Clear()
    {

    }
}
