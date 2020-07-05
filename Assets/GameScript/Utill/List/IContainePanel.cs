using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainePanel :MonoBehaviour
{
    public virtual bool SetText(string text)
    {
        return true;
    }
    public virtual bool SetSubText(string Text)
    {
        return true;
    }
    public virtual bool SetSprite(Sprite sprite)
    {

        return true;
    }
}
