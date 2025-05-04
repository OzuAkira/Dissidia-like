using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterSelect : MonoBehaviour
{
    Arrow _arrow;
    void Start()
    {
        _arrow = gameObject.GetComponent<Arrow>();
    }
}
