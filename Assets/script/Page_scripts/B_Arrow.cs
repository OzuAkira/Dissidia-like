using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class B_Arrow : MonoBehaviour
{
    Arrow _arrow;
    public void UpdateList(Transform center)
    {
        _arrow = gameObject.GetComponent<Arrow>();
        
        Transform childObj;
        menuScript mS;
        for(int i = 1; i <= center.childCount; i++)
        {
            childObj = center.GetChild(i-1);
            mS = childObj.GetComponent<menuScript>();
            _arrow.menu[i] = mS;
        }
        
    }
}
