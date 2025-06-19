using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static CharacterDB;

public class turnManager : MonoBehaviour
{
    [SerializeField] F_numberSetting f_NumberSetting;
    [SerializeField] Character_table characterTable;
    //エネミーテーブルもここに入れる
    private List<List<int>> speedList;

    private void Start()
    {
        f_NumberSetting = gameObject.GetComponent<F_numberSetting>();
        for (int i = 0; i < f_NumberSetting.num_id_cha.Length; i++)
        {
            foreach (parameters x in characterTable._characterDB)
            {
                if (x.Character_id == f_NumberSetting.num_id_cha[i])
                {
                    List<int> id_speed; 
                    id_speed.Add();
                }
            }
        }
         _parameters.OrderBy(_parameters => _parameters.speed);

    }

}
