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

    private List<GameObject> turnList = new List<GameObject>();

    private List<List<int>> speedList = new List<List<int>>();
    private List<int> id_speed = new List<int>();

    private int oneFram = 0;


    public List<List<int>> sorted_speedList = new List<List<int>>();
    
    public void set()//コルーチン等で実行するタイミングを測る
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
           foreach (enemy_parameters y in enemyTable._enemyDB)
                {
                    ii--;//エネミーのIDは負の値で分岐させる
                    id_speed.Add(ii);
                    id_speed.Add(y.speed);
                    speedList.Add(id_speed);
                    id_speed = new List<int>();
               } 
           sorted_speedList = speedList.OrderByDescending(item => item[1]).ToList();
        StartCoroutine( firstIcon());//後で消す
        }
    
    

    public IEnumerator firstIcon()//恐らくVoidになりそう
    {
        Debug.Log("start");
        int _count = 0;
        yield return new WaitForSeconds(3);
        while(_count < 6)
        {
            create_a_TurnIcon();
            _count++;
        }
    }

    void create_a_TurnIcon()
    {
        if (oneFram > (sorted_speedList.Count - 1)) oneFram = 0;

        Debug.Log("fram= " + oneFram);
        Debug.Log("count= " + sorted_speedList.Count);

        if (sorted_speedList[oneFram][0] >= 0)
        {
            GameObject _turn = Instantiate(f_Icon[sorted_speedList[oneFram][0]], bacePos, Quaternion.identity);
            turnList.Add(_turn);
            bacePos += addPos;
            oneFram++;
        }
        else
        {
            Debug.Log(sorted_speedList[oneFram][0]);
            GameObject _tum_e = Instantiate(e_Icon[sorted_speedList[oneFram][0] * -1], bacePos, Quaternion.identity);
            turnList.Add(_tum_e);
            bacePos += addPos;
            oneFram++;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            create_a_TurnIcon();
        }

    }
}
