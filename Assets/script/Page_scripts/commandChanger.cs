using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class commandChanger : MonoBehaviour
{
    BattleArrow _arrow;
    public void UpdateList(Transform center)
    {
        _arrow = gameObject.GetComponent<BattleArrow>();
        
        GameObject childObj;
        for(int i = 1; i <= center.childCount; i++)
        {
            childObj = center.GetChild(i-1).gameObject;
            _arrow.menu[i] = childObj;
        }
        
    }
}
