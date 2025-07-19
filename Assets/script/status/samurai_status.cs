using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static prameterDB;

public class samurai_status : MonoBehaviour
{
    GameObject gm;
    buffList bufflist;
    List<string> buff_list = new List<string>();
    private void Start()
    {
        gm = GameObject.Find("GamMaster");
        bufflist = Resources.Load<buffList> ("New Buff List");
        
    }
    public void takebuff(int buff_index)
    {

    }

}
