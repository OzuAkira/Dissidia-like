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
        for(int i=0;i<memberlist.Length;i++)//���L�����N�^�[��I�������ۂɁA�J�[�\�����ꏏ�ɔ�\���ɂ��鏈��
        {
            if(memberlist[i].activeSelf == false)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
