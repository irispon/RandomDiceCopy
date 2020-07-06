using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSlotPuncher : MonoBehaviour
{

    [SerializeField]
    GameObject diceSlot;

    public int xSize;
    public int ySize;
    public int RotateZ = 180;

    Dictionary<Vector2, GameObject> diceSlots;

    public void Start()
    {
        diceSlots = new Dictionary<Vector2, GameObject>();
        for(int y =0; y < ySize; y++)
        {
            for(int x =0; x<xSize; x++)
            {
                GameObject dice_slot= Instantiate(diceSlot);
                dice_slot.name = x + "," + y;
                dice_slot.transform.SetParent(transform);
                SizeFitter.FittingSize(dice_slot);
                diceSlots.Add(new Vector2(x, y), dice_slot);
                dice_slot.transform.Rotate(new Vector3(0, 0, RotateZ));
            }

        }
     


    }

}
