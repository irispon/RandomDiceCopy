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
    [SerializeField]
    public GameObject eye;
    public List<DiceEye> eyes;
    Dice[] otherDices;
    [HideInInspector]public int diceEye = 1;
    public SpriteRenderer sprite;
    // Start is called before the first frame update

    Dice container;
    Vector3 tmpPositon;
    //  ObjectPool objectPool;
   
    void Awake()
    {
        child = GetComponent<PoolChild>();
        //tag = diceStatus.diceName;
        sprite = GetComponent<SpriteRenderer>();
        name = nameof(Dice);
        eyes = new List<DiceEye>();


    }

    public void SetDiceStatus(DiceStatus diceStatus)
    {
        if (sprite == null)
        {
            sprite = GetComponent<SpriteRenderer>();
        }
        this.diceStatus = diceStatus;
       
        sprite.sprite = diceStatus.sprite;
        MakeEye(diceEye);
    }
    // Update is called once per frame

    public void MakeEye(int eye)
    {
       
       GameObject eyeObject= Instantiate(this.eye);
       DiceEye diceEye = eyeObject.GetComponent<DiceEye>();
       SizeFitter.FittingContent(eyeObject, gameObject);
    
       diceEye.Init(this);
        foreach (DiceEye eyeObj in eyes)
        {
            eyeObj.ChangeSprite(diceStatus.dotSprite);
        }
       eyes.Add(diceEye);
        //여기 이후론 눈 숫자에 따라서 위치 조정

        switch (eye)
        {
            case 2:
                eyes[0].transform.localPosition = new Vector3(-0.25f , 0);
                eyes[1].transform.localPosition = new Vector3(0.25f, 0);
                break;
            case 3:
                eyes[0].transform.localPosition = new Vector3(-0.25f, 0.25f);
                eyes[1].transform.localPosition = new Vector3(0, 0);
                eyes[2].transform.localPosition = new Vector3(0.25f, -0.25f);
                break;
            case 4:
                eyes[0].transform.localPosition = new Vector3(-0.25f, 0.25f);
                eyes[1].transform.localPosition = new Vector3(0.25f, 0.25f);
                eyes[2].transform.localPosition = new Vector3(-0.25f, -0.25f);
                eyes[3].transform.localPosition = new Vector3(0.25f, -0.25f);
                break;
        }
     
    }

    void Update()
    {
        
    }
    
    void LevelUp()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        tmpPositon = transform.position;
        Debug.Log("테스트");
        
        gameObject.transform.position = Mouse.GetMousePosition();
        sprite.sortingLayerName = "UI";
        foreach(DiceEye eye in eyes)
        {
            eye.sprite.sortingLayerName = "UI";
        }

       
        StartCoroutine(CallBack.waitThenCallback(0, () => {

            foreach (DiceSlot otherDice in GameMaster.GetInstance().pullDiceSlots)
            {
                if ((!diceStatus.Equals(otherDice.GetDiceInfo())) || !diceEye.Equals(otherDice.dice.diceEye))
                {
                    //  Debug.Log("칼라테스트");

                    otherDice.dice.sprite.color = new Color32(255, 255, 255, 100);


                }
            }
            
         


        }));
     



    }



    public void OnDrag(PointerEventData eventData)
    {

        //Debug.Log("드래깅");
        //  correctVector = renderer.size/2;
        gameObject.transform.position = Mouse.GetMousePosition();

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        sprite.sortingLayerName = "Unit";
        foreach (DiceEye eye in eyes)
        {
            eye.sprite.sortingLayerName = "Unit";
        }

  
          

        foreach (DiceSlot otherDice in GameMaster.GetInstance().pullDiceSlots)
        {
            otherDice.dice.sprite.color = new Color32(255, 255, 255, 255);
        }


      
        if (container != null)
        {
            DiceStatus containDiceStatus = container.diceStatus;
      
        

        //다이스 이름과 다이스 눈이 같으면
        if (diceStatus.diceName.Equals(containDiceStatus.diceName) && diceEye == container.diceEye)
        {
            if (diceEye<4)
            {
                GameMaster.GetInstance().SynthesisDice(gameObject, container.gameObject);
            }
            
        }
        }
        transform.position = tmpPositon;
        Debug.Log("드래그 종료" + name);
       
    }

    public void OnDrop(PointerEventData eventData)
    {
       // Debug.Log("드롭"+name);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // sprite.color = new Color32(255, 255, 255, 100);
       // Debug.Log("Point Enter"+name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //sprite.color = new Color32(255, 255, 255, 100);
    }
    public void Clear()
    {
        diceEye = 1;
        foreach (DiceEye eye in eyes)
        {
           Destroy(eye.gameObject);

        }
        eyes.Clear();
        child.Turn();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Dice")
        {
            Debug.Log(collision.gameObject.name);
            container = collision.gameObject.GetComponent<Dice>(); 

        }

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Dice")
        {
           
            container = collision.gameObject.GetComponent<Dice>();

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
       
        container = null;
    }

}
