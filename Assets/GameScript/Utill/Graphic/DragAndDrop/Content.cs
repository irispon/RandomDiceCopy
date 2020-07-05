using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Content : MonoBehaviour,IDrop,IDrag 
{

    protected Container container;
    // Start is called before the first frame update
    public void Start()
    {
        container = Container.instance;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log(this.name +"OnBeginDrag");
        container.content = this.gameObject;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        
       //이미지 끌려가는 걸 표현(중요도 낮음)
    }

    public virtual void OnDrop(PointerEventData eventData)
    {
        try
        {
            Transform containerContent = container.content.transform;
            Debug.Log("변경" + container.content.name);
            if (!containerContent.transform.parent.Equals(transform.parent))
            {
                containerContent.transform.SetParent(transform.parent);
            }
            container.content.transform.SetSiblingIndex(transform.GetSiblingIndex());
            container.content = null;
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        if (container.content == this.gameObject) container.content = null;
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        try
        {
            GameObject content = container.content;

            if (content != null && content != this.gameObject)
            {
                Debug.Log(content.name + "=>" + this.name);

            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

        //포인터가 들어가면 색 바뀜
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        //포인터가 나가면 원래 색
    }
}
