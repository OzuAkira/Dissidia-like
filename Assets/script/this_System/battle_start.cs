using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static prameterDB;

public class battle_start : menuScript
{
    [SerializeField] GameObject gm , setting , battleMap;
   // [SerializeField] prameterDB.Character_table character_table;
    [SerializeField] breakScene breakScene ;
    [SerializeField] turnManager tm ;
    public int _min = 1;
    private F_numberSetting f_NumberSetting;
    public parameters[] battleMember = { null,null,null};

    public override void select()
    {
        int _count = 0;
        f_NumberSetting = gm.GetComponent<F_numberSetting>();
        foreach (int x in f_NumberSetting.num_id_cha)
        {
            if (x >= 0)
            {
                _count++;
            }
        }
        if (_count >= _min)
        {
            setting.SetActive(false);
            battleMap.SetActive(true);
            breakScene.StartCoroutine("BreakStart");
            tm.set();

        }
        else
        {
            Debug.Log("キャラクターを選んでね");
            //return;
        }
        

    }
   
    
}
