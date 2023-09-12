using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour
{
    // 在你的类中定义变量来跟踪基地数量
    /*private int remainingBaseH = 2; // 初始有2个基地H
    private int remainingBaseO = 2; // 初始有2个基地O
    private int enemyCount = 0; // 初始场上没有敌人*/

    public GameObject playerPrefab;

    public GameObject[] enemyPrefabList;

    public bool createPlayer;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("BornTank", 1.0f);
        Destroy(gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 在基地死亡时更新剩余的基地数量
    /*private void UpdateRemainingBaseCount(string baseType)
    {
        if (baseType == "H")
        {
            remainingBaseH--;
        }
        else if (baseType == "O")
        {
            remainingBaseO--;
        }
    }*/

    private void BornTank()
    {
        if (createPlayer)
        {
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            int num = Random.Range(0, 3);
            Instantiate(enemyPrefabList[num], transform.position, Quaternion.identity);
        }



    }
}
