using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class doubleArrow : MonoBehaviour
{
    public menuScript[] _menu;
    public int _cursorIndex = 0;
    public Vector3 plusPos;
    public int listColams;
    bool right_count = false;
    bool left_count = false;
    bool up_count = false;
    bool down_count = false;
    public GameObject oldCorsor;
    private void Awake()
    {
        Debug.Log("‚¨‚È‚µ‚á‚·");
        oldCorsor.GetComponent<PlayerInput>().DeactivateInput();
        gameObject.GetComponent<PlayerInput>().ActivateInput();
    }
    public void OnMove(InputValue input)
    {
        var axis = input.Get<Vector2>();
        if(axis.x == 1 && right_count ==false) right_count = true;
        else if(axis.x == -1 && left_count ==false) left_count = true;

        if(axis.y == 1 && up_count ==false) up_count = true;
        else if(axis.y == -1 && down_count ==false) down_count = true;
    }
    void Update()
    {    
        int oldCursor = _cursorIndex;
        int cursorMax = _menu.Length;
        if (right_count)
        {
            _cursorIndex++;
            right_count = false;
        }
        else if (left_count)
        {
            _cursorIndex--;
            left_count = false;
        }
        else if(up_count)
        {
            _cursorIndex -= listColams;
            up_count = false;
        }
        else if(down_count)
        {
            _cursorIndex += listColams;
            down_count = false;
        }
        if(_cursorIndex < 0)_cursorIndex = 0;
        if (_cursorIndex >= cursorMax) _cursorIndex = _menu.Length-1;
        if (_cursorIndex != oldCursor) UpdateMenu();
    }
    public void OnFire()
    {
        _menu[_cursorIndex].select();
      //  Debug.Log("test");
    }
    void UpdateMenu()
    {
        int i = 0;
        foreach(menuScript menuTable in _menu)
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
