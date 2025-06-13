using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charaDate : menuScript
{
    public GameObject cObject,gm;


    public override void select()
    {
        cObject = GameObject.Find("c_cursor");
        gm = GameObject.Find("GamMaster");

        F_numberSetting f_Number = gm.GetComponent<F_numberSetting>();
        NewArrow cdb = cObject.GetComponent<NewArrow>();

        //Debug.Log("aaa");
        f_Number.character_select(cdb._cursorIndex);
    }
}
