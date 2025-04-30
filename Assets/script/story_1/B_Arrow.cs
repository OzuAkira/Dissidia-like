using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class B_Arrow : MonoBehaviour
{
    private Vector3 _velocity;
    public GameObject cursor;
    public int _cursorIndex;
    public menuScript[] menu;
    public bool right_count = false;
    public bool left_count = false;
    //public GameObject MasterObj;

    private void OnMove(InputValue value)
    {
        var axis = value.Get<Vector2>();
        if (axis.y == 1 && right_count == false) right_count = true;
        else if (axis.y == -1 && left_count == false) left_count = true;
    }
    void Update()
    {
        int oldCursor = _cursorIndex;
        int cursorMax = menu.Length;
        if (right_count)
        {
            _cursorIndex--;
            right_count = false;
        }
        else if (left_count)
        {
            _cursorIndex++;
            left_count = false;
        }



        if (_cursorIndex < 0) _cursorIndex = 0;
        if (_cursorIndex >= cursorMax) _cursorIndex = cursorMax-1;
        if (_cursorIndex != oldCursor) UpdateMenu();

        //x = 1.53 , y = -0.14

    }

    void OnFire()
    {
        menu[_cursorIndex].select();
    }

    void UpdateMenu()
    {
        int i = 0;
        foreach (menuScript menuTable in menu)
        {
            if (_cursorIndex == i)
            {
                menuTable.On();
                cursor.transform.position = menuTable.transform.position;
            }
            else menuTable.Off();
            i++;
        }
    }
    public void UpdateList(Transform center)
    {
        
        Transform childObj;
        menuScript mS;
        for(int i = 0; i < center.childCount; i++)
        {
            childObj = center.GetChild(i);
            mS = childObj.GetComponent<menuScript>();
            menu[i] = mS;
        }
        
    }
}
