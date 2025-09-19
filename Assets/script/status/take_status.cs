using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static prameterDB;

public class take_status : MonoBehaviour
{
    [SerializeField] Character_table characterTable;
    private int index;
    public int now_HP;
    public int MP;
    public int now_attack;
    public int now_defense;
    public int now_speed;
    public int[] now_element;
    public void set_status(
        int id,
        int battleNum ,
        int _hp ,
        int _mp ,
        int _attack ,
        int _degense ,
        int _speed ,
        int[] _elements )
    {
        index = battleNum;
        now_HP = _hp;
        MP = _mp;
        now_attack = _attack;
        now_defense = _degense;
        now_speed = _speed;
        now_element = _elements;
    }
}

