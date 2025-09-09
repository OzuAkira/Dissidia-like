using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;
using static prameterDB;
//このファイルは、敵出現演出の時間を調整するスクリプト

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
                    id_speed.Add(x.Character_id);
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
                id_speed.Add(y.Enemy_id * -1);
                speedList.Add(id_speed);
                    id_speed = new List<int>();
               } 
           sorted_speedList = speedList.OrderByDescending(item => item[1]).ToList();
        StartCoroutine( firstIcon());//後で消す
        }

    public GameObject enemy_1;
    public GameObject enemy_2;
    // Start is called before the first frame update
    void Start()
    {
        enemy_1.SetActive(false);
        enemy_2.SetActive(false);
    }
    int now_turn;
    public GameObject command;
    public IEnumerator firstIcon()//恐らくVoidになりそう
    {
        Debug.Log("start");
        int _count = 0;
        yield return new WaitForSeconds(3);
        enemy_1.SetActive(true);
        enemy_2.SetActive(true);
        yield return new WaitForSeconds(3);
        while (_count < 6)
        {
            create_a_TurnIcon();
            _count++;
        }
        yield return new WaitForSeconds(3);
        command.SetActive(true);
    }

    void create_a_TurnIcon()
    {
        if (oneFram > (sorted_speedList.Count - 1)) oneFram = 0;

        //Debug.Log("fram= " + oneFram);
        

        if (sorted_speedList[oneFram][0] >= 0)
        {
            Debug.Log("sortedList= " + sorted_speedList[oneFram][0]);
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
    int turnCounter = 0;
    void turn()
    {
        if (sorted_speedList[turnCounter][2] >= 0)
        {
            foreach (parameters x in characterTable._characterDB)
            {
                //if (x.Character_id == //アビリティデータベースのID)

            }
        }
    }
}
