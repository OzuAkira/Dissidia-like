using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charaDate : menuScript
{
    GameObject cObject,gm;

    private void Awake()
    {
        cObject = GameObject.Find("c_cursor");
        gm = GameObject.Find("GameMaster");
        
    }

    public override void select()
    {
        F_numberSetting f_Number = gm.GetComponent<F_numberSetting>();
        NewArrow cdb = cObject.GetComponent<NewArrow>();

        f_Number.character_select(cdb._cursorIndex);
    }
}
