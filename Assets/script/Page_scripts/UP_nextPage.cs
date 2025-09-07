using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UP_nextPage : abilities
{
    public PageMaster Master;
    public Image _Image;
    public Sprite _Sprite;
    public Arrow arrow;
    public override void Attack(int _)
    {
        Master.PageUpdate("u");
        _Image.sprite = _Sprite;
        arrow.UpdateMenu();
    }
    public override void information()
    {
        
    }
}
