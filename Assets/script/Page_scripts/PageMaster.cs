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
    public B_Arrow B_Arrow;
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
            Debug.Log("_vector‚ªnull");
        }
    }
    IEnumerator UP_ChangePage()
    {
        cursor.SetActive(false);
        _headList.transform.position = _tailList.transform.position;

        for (int i = 0; i < fps; i++)
        {
            _centerList.transform.localPosition += new Vector3(0, MpF, 0);
            _tailList.transform.localPosition += new Vector3(0, MpF, 0);
            yield return null;
        }
        _ = _headList;

        _headList = _centerList;
        _centerList = _tailList;
        _tailList = _;

        cursor.SetActive(true);

        Transform cl = _centerList.transform;
        B_Arrow.UpdateList(cl);
    }
    IEnumerator DOWN_ChangePage()
    {
        cursor.SetActive(false);
        _tailList.transform.position = _headList.transform.position;

        for (int i = 0; i < fps; i++)
        {
            _centerList.transform.localPosition += new Vector3(0, -MpF, 0);
            _headList.transform.localPosition += new Vector3(0, -MpF, 0);
            yield return null;
        }
        _ = _tailList;

        _tailList = _centerList;
        _centerList = _headList;
        _headList = _;
        

        cursor.SetActive(true);

        Transform cl = _centerList.transform;
        B_Arrow.UpdateList(cl);
    }



    public void TurnManager()
    {

    }
}
