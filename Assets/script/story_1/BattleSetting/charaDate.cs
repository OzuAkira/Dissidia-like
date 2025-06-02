using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charaDate : menuScript
{
    GameObject cObject = GameObject.Find("c_cursor");
    
    public override void select()
    {
        NewArrow cdb = cObject.GetComponent<NewArrow>();

    }
}
