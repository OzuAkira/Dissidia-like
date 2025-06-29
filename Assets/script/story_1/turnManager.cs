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
    [SerializeField] Vector2 bacePos , addPos;
    [SerializeField] GameObject[] f_Icon , e_Icon;
    private int count = 0;

    private List<GameObject> turnList = new List<GameObject>();

    private List<List<int>> speedList = new List<List<int>>();
    private List<int> id_speed = new List<int>();

    public List<List<int>> sorted_speedList = new List<List<int>>();
    private void Start()//�R���[�`�����Ŏ��s����^�C�~���O�𑪂�
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
                        //int a = x.Character_id;
                        id_speed.Add(i);//x.Character_id);
                        id_speed.Add(x.speed);
                        speedList.Add(id_speed);
                        id_speed = new List<int>();

                    }
                }

            }
                int ii = 0;
                foreach (enemy_parameters y in enemyTable.story1_enemyDB)
                {
                    ii--;//�G�l�~�[��ID�͕��̒l�ŕ��򂳂���
                    id_speed.Add(ii);
                    id_speed.Add(y.speed);
                    speedList.Add(id_speed);
                    id_speed = new List<int>();
                }

            
            sorted_speedList = speedList.OrderByDescending(item => item[1]).ToList();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            while (count < 6)//������turnIcon��\�����Ă���
            {
                createTurnIcon();
            }
        }
    }

    void createTurnIcon()
    {
        foreach (var x in sorted_speedList)
        {
            if (count >= 6) break;
            else
            {
                Debug.Log("id=" + x[0] + "  speed=" + x[1]);
                if (x[0] >= 0)
                {
                    GameObject _turn = Instantiate(f_Icon[x[0]], bacePos, Quaternion.identity);
                    turnList.Add(_turn);
                    bacePos += addPos;
                }
                else
                {
                    GameObject _tum_e = Instantiate(e_Icon[x[0] * -1], bacePos, Quaternion.identity);
                    turnList.Add(_tum_e);
                    bacePos += addPos;
                }
                count++;
            }
        }
    }

}
