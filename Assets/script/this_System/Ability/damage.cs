using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static prameterDB;

public class damage : MonoBehaviour
{
    [SerializeField] enemyTable enemyTable;
    public GameObject[] enemy;
    void takeDamage(int target , int damage)
    {
        enemyTable._enemyDB[target].HP -= damage; 
    }
    /*IEnumerator totaleDamage(int t , int d)
    {

    }*/
}
