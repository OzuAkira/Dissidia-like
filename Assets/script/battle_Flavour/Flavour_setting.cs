using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flavour_setting : menuScript
{
    public GameObject characterList;
    public GameObject gm;
    public int favour_number;

    //public GameObject cursor;
    void Awake()
    {
        characterList.SetActive(false);
    }
    public override void select()
    {
        StartCoroutine(number());
    }



    void Update()
    {
        if (characterList.activeSelf == true) gameObject.SetActive(false);
    }
    IEnumerator number()
    {
        F_numberSetting f_NumberSetting = gm.GetComponent<F_numberSetting>();
        f_NumberSetting.F_Num = favour_number;
        //yield return new WaitForSeconds(1f);
        yield return null;
        characterList.SetActive(true);
    }
}
