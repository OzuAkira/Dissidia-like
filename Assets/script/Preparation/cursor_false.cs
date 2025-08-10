using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class cursor_false : MonoBehaviour
{
    public GameObject[] memberlist;
    void Update()
    {
        for(int i=0;i<memberlist.Length;i++)//一回キャラクターを選択した際に、カーソルも一緒に非表示にする処理
        {
            if(memberlist[i].activeSelf == false)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
