using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static prameterDB;

public class turnManager : MonoBehaviour
{
    F_numberSetting f_NumberSetting;
    [SerializeField] Character_table characterTable;
    [SerializeField] enemyTable enemyTable;
    private List<List<int>> speedList = new List<List<int>>();
    private List<int> id_speed = new List<int>();
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            f_NumberSetting = gameObject.GetComponent<F_numberSetting>();
            for (int i = 0; i < f_NumberSetting.num_id_cha.Length; i++)
            {
                foreach (parameters x in characterTable._characterDB)
                {
                    //Debug.Log(i);
                    if (x.Character_id == f_NumberSetting.num_id_cha[i])
                    {
                        int a = x.Character_id;
                        id_speed.Add(a);//x.Character_id);
                        id_speed.Add(x.speed);
                        speedList.Add(id_speed);
                        id_speed = new List<int>();

                    }
                }

            }
                int ii = 0;
                foreach (enemy_parameters y in enemyTable.story1_enemyDB)
                {
                    ii--;//エネミーのIDは負の値で分岐させる
                    id_speed.Add(ii);
                    id_speed.Add(y.speed);
                    speedList.Add(id_speed);
                    id_speed = new List<int>();
                }

            
            List<List<int>> sorted_speedList = speedList.OrderBy(item => item[1]).ToList();

            foreach (var x in sorted_speedList)
            {
                Debug.Log("id="+x[0]+"  speed="+x[1]);
            }
        }

    }

}
