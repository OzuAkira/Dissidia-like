using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UP_nextPage : menuScript
{
    public PageMaster Master;
    public override void select()
    {
        Master.PageUpdate("u");
    }
}
