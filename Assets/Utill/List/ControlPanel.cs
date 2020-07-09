using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour
{
    
    [SerializeField]
    Text text,subText;
    [SerializeField]
    Image sprite;
    public void Awake()
    {
      
    }
    public bool SetSprite(Sprite sprite)
    {
        if (this.sprite == null)
        {
            return false;
        }
        this.sprite.sprite = sprite;
        return true;
    }

    public bool SetSubText(string Text)
    {
        if (this.subText == null)
        {
            return false;
        }
        this.subText.text = Text;
        return true;

    }

    public bool SetText(string text)
    {
        if (this.text == null)
        {
            return false;
        }
        this.text.text = text;
        return true;
    }


}
