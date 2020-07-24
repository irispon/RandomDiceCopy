using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMaster : SingletonObject<BoardMaster>
{
    [SerializeField]
    public GameObject spwanPoint, destination;
    SpriteRenderer sprite;
    public Vector3 boardBound;
    Vector3 destinationBound;


    // Start is called before the first frame update
    void Start()
    {

        sprite = GetComponent<SpriteRenderer>();
        boardBound = sprite.sprite.bounds.extents;
        Debug.Log(boardBound);
        spwanPoint.transform.localPosition = -boardBound;
         



    }
    public Vector3 FirstVertex()
    {
        return -boardBound;
    }
    public Vector3 SecondVertex()
    {
     
        return new Vector3(-boardBound.x, boardBound.y);
    }
    public Vector3 ThirdVertex()
    {
       
        return boardBound;
    }
    public Vector3 FourthVertex()
    {
       
        return new Vector3(boardBound.x, -boardBound.y);
    }
}
