using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static prameterDB;

public class take_status : MonoBehaviour
{
    [SerializeField] Character_table characterTable;
    private int index;
    public float now_HP;
    public float MP;
    public float now_attack;
    public float now_defense;
    public float now_speed;
    public int[] now_element;
    public void set_status(
        int id,
        int battleNum ,
        float _hp ,
        float _mp ,
        float _attack ,
        float _degense ,
        float _speed ,
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

