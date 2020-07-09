using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option 
{
    public bool Title { get; private set; } = true;
    public bool SubTitle { get; private set; } = true;
    public bool Sprite { get; private set; } = true;
 
   public Option(bool Title, bool SubTitle, bool Sprite)
    {
        this.Title = Title;
        this.SubTitle = SubTitle;
        this.Sprite = Sprite;

    }

    public Option()
    {

    }

}
