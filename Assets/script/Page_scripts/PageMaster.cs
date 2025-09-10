using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageMaster : MonoBehaviour
{

    public GameObject _headList;
    public GameObject _centerList;
    public GameObject _tailList;
    public int fps = 60;
    public float MpF = 16f;
    public GameObject cursor;
    public commandChanger B_Arrow;
    private GameObject _;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void PageUpdate(string _vector)
    {
        if (_vector == "u" || _vector == "U")
        {
           
            StartCoroutine("UP_ChangePage");
            
        }
        else if (_vector == "d" || _vector == "D")
        {
            StartCoroutine("DOWN_ChangePage");
            
        }
        else
        {
            Debug.Log("_vectorがnull");
        }
    }
    public bool Upcounter = false; public bool Downcounter = false;//3ページの場合はcounter を常にFalseに
    IEnumerator UP_ChangePage()
    {
        cursor.SetActive(false);

        _headList.transform.position = _tailList.transform.position;
        if (Upcounter)
        {
            _ = _headList;
            _headList = _tailList;
            _tailList = _;
            Upcounter = false;
            Downcounter = false;
        }
        else if(Downcounter)
        {
            Upcounter = false;
            Downcounter = false;
        }
        else
        {
            Upcounter = true;
            Downcounter = false;
        }
            //Vector3 tailPos = _tailList.transform.position;

            for (int i = 0; i < fps; i++)
            {
                _centerList.transform.localPosition += new Vector3(0, MpF, 0);
                _tailList.transform.localPosition += new Vector3(0, MpF, 0);
                yield return null;
            }

        //3ページの場合はこっち
        
         _ = _headList;

        _headList = _centerList;
        _centerList = _tailList;
        _tailList = _;
        

        //2ページの場合はこっち
        /*
        _headList = _centerList;
        _centerList = _tailList;
        _tailList = _headList;

        _headList.transform.position = tailPos;
        */

        cursor.SetActive(true);

        Transform cl = _centerList.transform;
        B_Arrow.UpdateList(cl);
    }
    IEnumerator DOWN_ChangePage()
    {
        cursor.SetActive(false);
        _tailList.transform.position = _headList.transform.position; //3ページの場合はこっち

        if (Downcounter)
        {
            _ = _headList;
            _headList = _tailList;
            _tailList = _;
            //Upcounter = true;
            Downcounter = false;
            Upcounter = false;
        }
        else if(Upcounter)
        {
            Downcounter = false;
            Upcounter = false;
        }
        else
        {
            Upcounter = false;
            Downcounter = true;
        }

        for (int i = 0; i < fps; i++)
        {
            _centerList.transform.localPosition += new Vector3(0, -MpF, 0);
            _headList.transform.localPosition += new Vector3(0, -MpF, 0);
            yield return null;
        }

        //3ページの場合はこっち

        
         _ = _tailList;

        _tailList = _centerList;
        _centerList = _headList;
        _headList = _;
        
        
        //2ページの場合

        /*

        _tailList = _centerList;
        _centerList = _headList;
        _headList = _tailList;

        _tailList.transform.position = headPos;
        */

        cursor.SetActive(true);

        Transform cl = _centerList.transform;
        B_Arrow.UpdateList(cl);
    }



    public void TurnManager()
    {

    }
}
