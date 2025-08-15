
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class active_charactorList : menuScript
{
    public GameObject characterList,gm,mylist;
    private Image image;
    public int favour_number;

    //public GameObject cursor;
    void Awake()
    {
        characterList.SetActive(false);
        
    }
    public override void select()
    {
        StartCoroutine(number());
    }
    /*
    public void updateWindow(int[] Sequential)
    {
        image = gameObject.GetComponent<Image>();
        //Debug.Log("ccc");
        foreach(parameters _parameters in character_Table._characterDB)
        {
            if(_parameters.Character_id == Sequential[favour_number])
            {
                Sprite icon = _parameters.characterIcon;
                image.sprite = icon;
                OffImage = icon;
                OnImage = icon;
                
            }
            
        }
    }
    */
    private const string BASE_ADDRESS = "Assets/dataBase/charactor";
    string assetAddress;
    bool searchFlag = false;
    async public void updateWindow(int[] assetindex)
    {
        image = gameObject.GetComponent<Image>();

        indexDataBase AssetsIndex = await Addressables.LoadAssetAsync<indexDataBase>("Assets/dataBase/indexDataBase.asset").Task;


        Debug.Log(assetindex[favour_number]);

        if (assetindex[favour_number] >= 0)
        {
            assetAddress = AssetsIndex.index[assetindex[favour_number]];
            searchFlag = true;
        }
        else
            searchFlag = false;


            Addressables.Release(AssetsIndex);


        //Ç±Ç±Ç©ÇÁçÁÇÕï ÇÃèàóù
        if (searchFlag)
        {
            string _address = $"{BASE_ADDRESS}/{assetAddress}.asset";
            create_dataBase charactorAsset = await Addressables.LoadAssetAsync<create_dataBase>(_address).Task;

            Sprite icon = charactorAsset.Icon;
            image.sprite = icon;
            OffImage = icon;
            OnImage = icon;

            Addressables.Release(charactorAsset);
        }
    }


    IEnumerator number()
    {
        save_charactor_id saveCID = gm.GetComponent<save_charactor_id>();
        saveCID.F_Num = favour_number;



        characterList.SetActive(true);
        while (characterList.activeSelf == false) yield return null;
        mylist.SetActive(false);
    }
}
