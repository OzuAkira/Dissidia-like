using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using static prameterDB;

public class Flavour_setting : menuScript
{
    public GameObject characterList,gm,mylist;
    private Image image;
    public int favour_number;

    public prameterDB.Character_table character_Table;

    //public GameObject cursor;
    void Awake()
    {
        characterList.SetActive(false);
        
    }
    public override void select(int _)
    {
        StartCoroutine(number());
    }

    public void updateWindow(int[] Sequential)
    {
        image = gameObject.GetComponent<Image>();
        //Debug.Log("ccc");
        foreach(parameters _parameters in character_Table._characterDB)
        {
            if(_parameters.Character_id == Sequential[favour_number])
            {
                Sprite icon = _parameters.characterIcon;
                image.sprite = icon;
                OffImage = icon;
                OnImage = icon;
            }
            
        }
    }

    IEnumerator number()
    {
        F_numberSetting f_NumberSetting = gm.GetComponent<F_numberSetting>();
        f_NumberSetting.F_Num = favour_number;



        characterList.SetActive(true);
        while (characterList.activeSelf == false) yield return null;
        mylist.SetActive(false);
    }
}
