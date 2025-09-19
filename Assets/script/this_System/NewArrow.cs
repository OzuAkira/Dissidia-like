using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewArrow : MonoBehaviour
{
    private bool right;
    private bool left;
    private bool up;
    private bool down;
    public menuScript[] menus;
    public int menuLine;
    public int _cursorIndex = 0;
    public Vector3 plusPos = new Vector3(100f, -30f, 0);

    void Update()
    {
        input_function();
        int oldCursor = _cursorIndex;
        int cursorMax = menus.Length;
        indexControl();
        if(_cursorIndex < 0)_cursorIndex = menus.Length - 1;
        if(_cursorIndex >= cursorMax) _cursorIndex = 0;
        if (_cursorIndex != oldCursor) UpdateMenue();
    }
    void input_function()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            if (Input.GetAxis("Horizontal") > 0) right = true;
            else left = true;
        }
        if (Input.GetButtonDown("Vertical"))
        {
            if (Input.GetAxis("Vertical") > 0) up = true;
            else down = true;
        }
    }
    void indexControl()
    {
        if (right)
        {
            _cursorIndex++;
            if (_cursorIndex % menuLine == 0) _cursorIndex--;
            right = false;
        }
        else if (left)
        {
            _cursorIndex--;
            if ((_cursorIndex + 1) % menuLine == 0) _cursorIndex++;
            left = false;
        }
        else if (up)
        {
            _cursorIndex -= menuLine;
            if (_cursorIndex < 0) _cursorIndex += menuLine;
            up = false;
        }
        else if (down)
        {
            _cursorIndex += menuLine;
            if (_cursorIndex > menus.Length) _cursorIndex -= menuLine;
            down = false;
        }
        else if (Input.GetKeyDown(KeyCode.Return)) menus[_cursorIndex].select(0);
  
    }
    void UpdateMenue()
    {
        int i = 0;
        foreach (menuScript menueTable in menus)
        {
            if (_cursorIndex == i)
            {
                menueTable.On();
                gameObject.transform.localPosition = menueTable.transform.localPosition + plusPos;
            }
            else menueTable.Off();
            i++;
        }
    }
    
}
