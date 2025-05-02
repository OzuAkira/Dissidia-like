using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Arrow : MonoBehaviour
{
    private Vector3 _velocity;
    public GameObject cursor;
    public int _cursorIndex;
    public menuScript[] menu;
    public bool right_count = false;
    public bool left_count = false;
    
    private void OnMove(InputValue value)
    {
        var axis = value.Get<Vector2>();
        if(axis.x == 1 && right_count ==false) right_count = true;
        else if(axis.x == -1 && left_count ==false) left_count = true;
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
       /* else if()
        {
            menu[_cursorIndex].select();
        }*/


        if(_cursorIndex < 0)_cursorIndex = menu.Length-1;
        if (_cursorIndex >= cursorMax) _cursorIndex = 0;
        if (_cursorIndex != oldCursor) UpdateMenu();
        
        //x = 1.53 , y = -0.14

    }
    void OnFire()
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
                
                cursor.transform.localPosition = menuTable.transform.localPosition + new Vector3(100f,-30f,0);
            }
            else menuTable.Off();
            i++;
        }
    }
}
