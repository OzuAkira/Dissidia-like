using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static prameterDB;

public class battle_start : menuScript
{
    [SerializeField] GameObject gm , setting , battleMap ,charactorObj;
   // [SerializeField] prameterDB.Character_table character_table;
    [SerializeField] breakScene breakScene ;
    [SerializeField] turnManager tm ;
    [SerializeField] Character_table characterTable;

    public int _min = 1;
    private F_numberSetting f_NumberSetting;
    public parameters[] battleMember = { null,null,null};

    public override void select()
    {
        int _count = 0;
        int index = 0;

        f_NumberSetting = gm.GetComponent<F_numberSetting>();
        foreach (int x in f_NumberSetting.num_id_cha)
        {
            index++;

            if (x >= 0)
            {
                _count++;

                foreach (var charaElement in characterTable._characterDB)
                {
                    if (charaElement.Character_id == x)
                    {
                        float x_pos = 0.7f;
                        float z_pos = 0.001f;
                        GameObject Obj;
                        SpriteRenderer _spriteRenderer;
                        switch (index) { 
                            case 1:
                                Obj = Instantiate(charactorObj, new Vector3(x_pos, 0.7f, z_pos), Quaternion.identity , battleMap.transform);
                                _spriteRenderer = Obj.GetComponent<SpriteRenderer>();
                                _spriteRenderer.sprite = charaElement.image;
                                Obj = null;
                                break;
                            case 2:
                                Obj = Instantiate(charactorObj, new Vector3(x_pos, -0.05f, z_pos), Quaternion.identity, battleMap.transform);
                                _spriteRenderer = Obj.GetComponent<SpriteRenderer>();
                                _spriteRenderer.sprite = charaElement.image;
                                Obj = null;
                                break;
                            case 3:
                                Obj = Instantiate(charactorObj, new Vector3(x_pos, -0.77f, z_pos), Quaternion.identity, battleMap.transform);
                                _spriteRenderer = Obj.GetComponent<SpriteRenderer>();
                                _spriteRenderer.sprite = charaElement.image;
                                Obj = null;
                                break;
                        }
                    }
                }
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
