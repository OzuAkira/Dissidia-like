using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class abilities : MonoBehaviour
{
    public string ability_name;
    public int ability_remainder;
    public string element;
    public string weapon_type;//int�ł��ǂ�

    public abstract void Attack(int target);

    public abstract void information();
}
