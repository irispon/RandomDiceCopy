using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MenuDrag : MonoBehaviour,IDragHandler,IPointerDownHandler
{
    private const float dragSpeed = 300f;
    private RectTransform dragOrigin;
    private Vector2 originPoint;

    protected void Awake()
    {
        dragOrigin = gameObject.GetComponent<RectTransform>();

    }

    public void OnDrag(PointerEventData eventData)
    {
      
        
        Vector2 pos = originPoint+ eventData.position- eventData.pressPosition;
        dragOrigin.anchoredPosition = pos;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        originPoint = dragOrigin.anchoredPosition;
    }


}
