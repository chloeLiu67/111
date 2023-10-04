using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour
{
    // ��������ж�����������ٻ�������
    /*private int remainingBaseH = 2; // ��ʼ��2������H
    private int remainingBaseO = 2; // ��ʼ��2������O
    private int enemyCount = 0; // ��ʼ����û�е���*/

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

    // �ڻ�������ʱ����ʣ��Ļ�������
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
