using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Arrow : MonoBehaviour
{
    //private Vector3 _velocity;
    //public GameObject cursor;
    public bool isY;
    public int _cursorIndex = 0;
    //public bool parameters = false;
    public int listColams;
    public Vector3 plusPos = new Vector3(100f,-30f,0);
    public menuScript[] menu;
    public bool right_count = false;
    public bool left_count = false;
    public bool up_count = false;
    public bool down_count = false;

    
    public void OnMove(InputValue value)
    {
        var axis = value.Get<Vector2>();
        
            if(isY)
            {
                if(axis.y == 1 && right_count ==false) right_count = true;
                else if(axis.y == -1 && left_count ==false) left_count = true;
            }
            else
            {
                if(axis.x == 1 && right_count ==false) right_count = true;
                else if(axis.x == -1 && left_count ==false) left_count = true;
            }
        
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
        else if(up_count)
        {
            _cursorIndex += listColams;
            up_count = false;
        }
        else if(down_count)
        {
            _cursorIndex -= listColams;
            down_count = false;
        }
       /* else if()
        {
            menu[_cursorIndex].select();
        }*/


        if(_cursorIndex < 0)_cursorIndex = menu.Length-1;
        if (_cursorIndex >= cursorMax) _cursorIndex = 0;
        if (_cursorIndex != oldCursor) UpdateMenu();
        
        //x = 1.53 , y = -0.14

    }
    public void OnFire()
    {
        menu[_cursorIndex].select();
      //  Debug.Log("test");
    }
    void UpdateMenu()
    {
        int i = 0;
        foreach(menuScript menuTable in menu)
        {
            if(_cursorIndex == i)
            {
                menuTable.On();
                
                gameObject.transform.localPosition = menuTable.transform.localPosition + plusPos;
            }
            else menuTable.Off();
            i++;
        }
    }
}
