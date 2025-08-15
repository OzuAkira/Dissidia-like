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

    private List<string> indexList;
   // private enemy enemy;

    async void LoadIndex()
    {
        indexDataBase AssetsIndex = await Addressables.LoadAssetAsync<indexDataBase>("Assets/dataBase/indexDataBase").Task;

        indexList = AssetsIndex.index;

        Addressables.Release(AssetsIndex);

        indexDataBase enemyDataBase = await Addressables.LoadAssetAsync<indexDataBase>("Assets / dataBase / enemy / EnemyAsset").Task;

     //   enemy = enemyDataBase.enemies[0];

        Addressables.Release(AssetsIndex);

    }

    async void Load_charactor(string assetAddress)
    {
        string BASE_ADDRESS = "Assets/dataBase/charactor";
        string _address = $"{BASE_ADDRESS}/{assetAddress}";
        create_dataBase charactorAsset = await Addressables.LoadAssetAsync<create_dataBase>(_address).Task;

        id_speed.Add(int.Parse(charactorAsset.ID));//x.Character_id);
        id_speed.Add(charactorAsset.speed);
        speedList.Add(id_speed);
        id_speed = new List<int>();

        Addressables.Release(charactorAsset);
    }


    public void set()//コルーチン等で実行するタイミングを測る
    {

        f_NumberSetting = gameObject.GetComponent<save_charactor_id>();
        foreach (int x in f_NumberSetting.num_id_cha)
        {
            //Debug.Log(i);
            if (x <= indexList.Count())
                Load_charactor(indexList[x]);
            else if (x >= indexList.Count() * -1 && x < 0)
                Load_charactor(indexList[x * -1]);
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
        sorted_speedList = speedList.OrderByDescending(item => item[1]).ToList();
        StartCoroutine(firstIcon());//後で消す*/
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

