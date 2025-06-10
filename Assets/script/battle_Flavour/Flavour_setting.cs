using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flavour_setting : menuScript
{
    public GameObject characterList;
    public int favour_number;

    //public GameObject cursor;
    void Awake()
    {
        characterList.SetActive(false);
    }
    public override void select()
    { 
        F_numberSetting f_NumberSetting = GetComponent<F_numberSetting>();
        f_NumberSetting.F_Num = favour_number;
        characterList.SetActive(true);
    }



    void Update()
    {
        if (characterList.activeSelf == true) gameObject.SetActive(false);
    }
}
