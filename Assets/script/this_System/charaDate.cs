using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charaDate : menuScript
{
    GameObject cObject,gm;
    F_numberSetting f_Number;
    private void Awake()
    {
        cObject = GameObject.Find("c_cursor");
        gm = GameObject.Find("GameMaster");
        f_Number = gm.GetComponent<F_numberSetting>();
    }

    public override void select()
    {
        NewArrow cdb = cObject.GetComponent<NewArrow>();

        f_Number.character_select(cdb._cursorIndex);
    }
}
