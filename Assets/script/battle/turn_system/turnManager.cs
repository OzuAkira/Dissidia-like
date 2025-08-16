using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class turnManager : MonoBehaviour
{
    save_charactor_id f_NumberSetting;


    [SerializeField] Vector2 bacePos, addPos;
    [SerializeField] GameObject[] f_Icon, e_Icon;

    private List<GameObject> turnList = new List<GameObject>();

    private List<List<int>> speedList = new List<List<int>>();
    private List<int> id_speed = new List<int>();

    private int oneFram = 0;


    public List<List<int>> sorted_speedList = new List<List<int>>();

    private List<string> indexList = new List<string>();
    int enemySpeed;

   // private enemy enemy;

    async void LoadIndex()
    {

        indexDataBase AssetsIndex = await Addressables.LoadAssetAsync<indexDataBase>("Assets/dataBase/indexDataBase.asset").Task;
        Debug.Log("assetIndex = "+AssetsIndex.index);
        indexList = AssetsIndex.index;
        Addressables.Release(AssetsIndex);

        //今回は敵が1体だからリテラル
        create_dataBase enemyDataBase = await Addressables.LoadAssetAsync<create_dataBase>("Assets/dataBase/enemy/EnemyAsset.asset").Task;
        enemySpeed = enemyDataBase.speed;

        id_speed.Add(-1);//x.Character_id);
        id_speed.Add(enemySpeed);
        speedList.Add(id_speed);
        id_speed = new List<int>();

        Addressables.Release(enemyDataBase);
    }

    async void Load_charactor(int num , string assetAddress)
    {
        

        string BASE_ADDRESS = "Assets/dataBase/charactor";
        string _address = $"{BASE_ADDRESS}/{assetAddress}.asset";
        create_dataBase charactorAsset = await Addressables.LoadAssetAsync<create_dataBase>(_address).Task;

        id_speed.Add(num);//x.Character_id);
        id_speed.Add(charactorAsset.speed);
        speedList.Add(id_speed);
        id_speed = new List<int>();

        Addressables.Release(charactorAsset);
    }


    public IEnumerator set()//コルーチン等で実行するタイミングを測る
    {
        LoadIndex();

        f_NumberSetting = gameObject.GetComponent<save_charactor_id>();
        int _num = 0;
        while(indexList == null)
        {
            yield return null;
        }
        //Debug.Log(indexList[0]);
        foreach (int x in f_NumberSetting.num_id_cha)
        {
            if (x >= 0)
            {
                Load_charactor(_num, indexList[x]);
                _num++;
            }
        }









        /*
        int ii = 0;
        foreach (enemy_parameters y in enemyTable._enemyDB)
        {
            ii--;//エネミーのIDは負の値で分岐させる
            id_speed.Add(ii);
            id_speed.Add(y.speed);
            speedList.Add(id_speed);
            id_speed = new List<int>();
        }
        */
        sorted_speedList = speedList.OrderByDescending(item => item[1]).ToList();
        StartCoroutine(firstIcon());//後で消す
    }

    public GameObject enemy_1;
    public GameObject enemy_2;
    // Start is called before the first frame update
    void Start()
    {
        enemy_1.SetActive(false);
        enemy_2.SetActive(false);
    }

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

