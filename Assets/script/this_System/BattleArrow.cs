using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class BattleArrow : MonoBehaviour
{
    bool up_count, down_count ,
        right_count , left_count , 
        right_trigger , left_trigger= false;

    public int _cursorIndex , targetIndex = 0;
    public int listColams;
    public Vector3 plusPos = new Vector3(0f, 0, 0);
    public GameObject[] enemys , menu;
    public GameObject moveTargetObject;

    private void Start()
    {
        moveTargetObject = Instantiate(moveTargetObject);
        UpdateMenu(_cursorIndex, gameObject, menu, false);
        UpdateMenu(targetIndex, moveTargetObject, enemys, true);
    }

    void OnMove(InputValue iv)
    {
        Debug.Log("aaa");
        var axis = iv.Get<float>();
        if (axis == 1 && up_count == false) up_count = true;
        else if (axis == -1 && down_count == false) down_count = true;
    }
    private void Update()
    {
        cursorControl();
        targetControl();
    }
    void cursorControl()
    {
        int oldCursor = _cursorIndex;
        int cursorMax = menu.Length;
        if (up_count)
        {
            _cursorIndex--;
            up_count = false;
        }
        else if (down_count)
        {
            _cursorIndex++;
            down_count = false;
        }

        if (_cursorIndex < 0) _cursorIndex = 0;
        if (_cursorIndex >= cursorMax) _cursorIndex = menu.Length-1;
        if (_cursorIndex != oldCursor) UpdateMenu(_cursorIndex, gameObject , menu, false);
    }

    void targetControl()
    {
        int oldTarget = targetIndex;
        int cursorMax = enemys.Length;
        Debug.Log("cursorMax"+cursorMax);
        if (right_trigger)
        {
            targetIndex++;
            right_trigger = false;
        }
        else if (left_trigger)
        {
            targetIndex--;
            left_trigger = false;
        }
        if (targetIndex < 0) targetIndex = 0;
        if (targetIndex >= cursorMax) targetIndex = enemys.Length-1;
        if (targetIndex != oldTarget) UpdateMenu(targetIndex, moveTargetObject,enemys , true);
    }







    void OnTarget(InputValue _Value)
    {
        var target = _Value.Get<float>();
        if(target == 1 && right_trigger == false) right_trigger = true;
        else if(target == -1 && left_trigger == false) left_trigger = true;
    }

    void OnLR(InputValue _input)
    {
        var trigger = _input.Get<float>();
        if (trigger == 1 && right_count == false) right_count = true;
        else if (trigger == -1 && left_count == false) left_count = true;
    }




    public void OnFire()
    {
        abilities abilities = menu[_cursorIndex].GetComponent<abilities>();

        abilities.Attack(targetIndex);
    }
    public void UpdateMenu(int Index , GameObject moveObj , GameObject[] objects , bool target)
    {
        int i = 0;
        foreach (var Table in objects)
        {
            
            if (Index == i)
            {
                if (i == 1 || i == 2 || i == 3 || i == 4) plusPos = new Vector3(-1000,0,0);
                else  plusPos = new Vector3(0,0,0);
                if (target) plusPos = new Vector3(0, 0, 0);
                moveObj.transform.localPosition = Table.transform.localPosition + plusPos;
            }
            i++;

        }
    }

}
