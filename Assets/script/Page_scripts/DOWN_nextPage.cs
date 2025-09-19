using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DOWN_nextPage : abilities
{
    public PageMaster Master;
    public Image _Image;
    public Sprite _Sprite;
    //public BattleArrow arrow;

    GameObject MasterObject;
    private void Start()
    {
        MasterObject = GameObject.Find("GamMaster");
        Master = MasterObject.GetComponent<PageMaster>();
    }
    public override void Attack(int _)
    {
        Master.PageUpdate("d");
        _Image.sprite = _Sprite;
        //arrow.UpdateMenu();
    }
    public override void information()
    {

    }
}
