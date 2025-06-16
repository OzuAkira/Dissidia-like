using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterDB;

public class battle_start : menuScript
{
    [SerializeField] GameObject gm , setting , battleMap;
    [SerializeField] CharacterDB.Character_table character_table;
    [SerializeField] breakScene breakScene ;
    private F_numberSetting f_NumberSetting;
    public parameters[] battleMember = { null,null,null};
    
    public override void select()
    {
        f_NumberSetting = gm.GetComponent<F_numberSetting>();
        for (int i = 0; i < f_NumberSetting.num_id_cha.Length; i++)
        {
            foreach (parameters _parameters in character_table._characterDB)
            {
                if (_parameters.Character_id == f_NumberSetting.num_id_cha[i])
                {
                    Debug.Log(_parameters);//.Character_id);

                    battleMember[i]=_parameters;
                    
                    break;
                }
                
            }

        }
        
        setting.SetActive(false);
        battleMap.SetActive(true);
        breakScene.StartCoroutine("BreakStart");
    }
    /*
    IEnumerator _battle()
    {
        f_NumberSetting = gm.GetComponent<F_numberSetting>();
        foreach (parameters _DB in character_table._characterDB)
        {
            battleMember.Add(_DB);
        }

        battleMap.SetActive(true);
        yield return null;
    }
    */
}
