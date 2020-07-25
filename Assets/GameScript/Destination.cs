using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    GameObject board;
    HPControler controler;
    private void Awake()
    {
        board = GameObject.Find(BoardType.UserBoard.ToString());
        controler = board.GetComponent<GameMaster>().HPControler;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Monster")))
        {
            controler.GetDamage(1);
        }
       
    }
}
