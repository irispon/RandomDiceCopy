using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSlotPuncher : MonoBehaviour
{
    [SerializeField]
    int row, coloumn;
    [SerializeField]
    List<DiceSlot> slots;

    private void Awake()
    {

        RectTransform transform = GetComponent<RectTransform>();
        
    }
}
