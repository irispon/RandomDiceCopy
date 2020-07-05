using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent
{
    public void OnClick(Event @event)
    {
        if (Input.GetMouseButtonUp(0))
            @event();
        

        // 클릭시 반응
    }

    public void OnDrag(Event @event)
    {
        @event();
        // 클릭 후 드래스시 반응
    }
    public void OnHover(Event @event) {
        @event();
        // 마우스 오버
    }



    public delegate void Event();

}
/*이미 있는 거라 만들다가 말았음. 나중에 키보드 이벤트 때 비슷하게 만들면 괜찮을거 같음.*/