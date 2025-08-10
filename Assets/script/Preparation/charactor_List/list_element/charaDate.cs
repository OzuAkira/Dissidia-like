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

        save_charactor_id f_Number = gm.GetComponent<save_charactor_id>();
        two_dimension_arrow cdb = cObject.GetComponent<two_dimension_arrow>();

        //Debug.Log("cdb._cursorIndex = "+ cdb._cursorIndex);
        StartCoroutine(f_Number.character_select(cdb._cursorIndex));
        //myobj.SetActive(false);

    }
}
