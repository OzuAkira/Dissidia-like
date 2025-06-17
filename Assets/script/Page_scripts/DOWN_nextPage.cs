using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DOWN_nextPage : menuScript
{
    public PageMaster Master;
    public Image _Image;
    public Sprite _Sprite;
    public Arrow arrow;
    public override void select()
    {
        Master.PageUpdate("d");
        _Image.sprite = _Sprite;
        arrow.UpdateMenu();
    }
}
