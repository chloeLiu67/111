using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour
{
    //װ�γ�ʼ����ͼ������������
    //0.��1.wall2.barrier3.����Ч��4.����5.��6.����ǽ7.empty
    public GameObject[] item;

    private List<Vector3> itemPositionList = new List<Vector3>();

    public int Hx, Hy;
    public int Ox, Oy;

    private void Awake()
    {
        InitMap();
    }

    private void InitMap()
    {
        //ʵ������
        CreateItem(item[0], new Vector3(0, -7, 0), Quaternion.identity);
        //ǽ����
        CreateItem(item[1], new Vector3(-1, -7, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(1, -7, 0), Quaternion.identity);
        for (int i = -1; i < 2; i++)
        {
            CreateItem(item[1], new Vector3(i, -6, 0), Quaternion.identity);
        }

        

        //��ʼ�����
        CreateItem(item[7], new Vector3(-2, -7, 0), Quaternion.identity);
        GameObject go = Instantiate(item[3], new Vector3(-2, -7, 0), Quaternion.identity);
        go.GetComponent<Born>().createPlayer = true;


        //��������
        CreateItem(item[3], new Vector3(-9, 7, 0), Quaternion.identity);
        CreateItem(item[3], new Vector3(0, 7, 0), Quaternion.identity);
        CreateItem(item[3], new Vector3(9, 7, 0), Quaternion.identity);
       
        InvokeRepeating("CreateEnemy", 4, 4.5f);


        //ʵ������ͼ
        for (int i = 0; i < 65; i++)
        {
            CreateItem(item[1], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[2], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[4], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 22; i++)
        {
            CreateItem(item[5], CreateRandomPosition(), Quaternion.identity);
        }
        //ʵ�������˻���
        for (int i = 0; i < 2; i++)
        {
            /*int Hx = Random.Range(-9, 10);
            int Hy = Random.Range(0, 7);*/
            CreateItem(item[8], CreateRandomPosition(), Quaternion.identity);
            //Vector3 clone = new Vector3(Hx, Hy, 0);
            /*while (HasThePosition(clone))
            {
                Hx = Random.Range(-9, 10);
                Hy = Random.Range(0, 8);
            }*/

            /*//ǽ����
            CreateItem(item[1], new Vector3(Hx - 1, Hy, 0), Quaternion.identity);
            CreateItem(item[1], new Vector3(Hx + 1, Hy, 0), Quaternion.identity);
            //CreateItem(item[1], new Vector3(Hx-1, Hy+1, 0), Quaternion.identity);
            CreateItem(item[1], new Vector3(Hx, Hy + 1, 0), Quaternion.identity);
            //CreateItem(item[1], new Vector3(Hx-1, Hy+1, 0), Quaternion.identity);
            //CreateItem(item[1], new Vector3(Hx - 1, Hy - 1, 0), Quaternion.identity);
            CreateItem(item[1], new Vector3(Hx, Hy - 1, 0), Quaternion.identity);
            //CreateItem(item[1], new Vector3(Hx - 1, Hy - 1, 0), Quaternion.identity);*/


            /*int Ox = Random.Range(-9, 10);
            int Oy = Random.Range(0, 7);*/
            //Vector3 clone1 = new Vector3(Ox, Oy, 0);
            /*while (HasThePosition(clone1))
            {
                Ox = Random.Range(-9, 10);
                Oy = Random.Range(0, 8);
            }*/
            CreateItem(item[9], CreateRandomPosition(), Quaternion.identity);
           /* CreateItem(item[1], new Vector3(Ox - 1, Oy, 0), Quaternion.identity);
            CreateItem(item[1], new Vector3(Ox + 1, Oy, 0), Quaternion.identity);
            //CreateItem(item[1], new Vector3(Ox - 1, Oy + 1, 0), Quaternion.identity);
            CreateItem(item[1], new Vector3(Ox, Oy + 1, 0), Quaternion.identity);
            //CreateItem(item[1], new Vector3(Ox - 1, Oy + 1, 0), Quaternion.identity);
            //CreateItem(item[1], new Vector3(Ox - 1, Oy - 1, 0), Quaternion.identity);
            CreateItem(item[1], new Vector3(Ox, Oy - 1, 0), Quaternion.identity);
            //CreateItem(item[1], new Vector3(Ox - 1, Oy - 1, 0), Quaternion.identity);  */         
        }
    }
    private void CreateItem(GameObject createGameObject, Vector3 createPosition, Quaternion createRotation)
    {
        GameObject itemGo = Instantiate(createGameObject, createPosition, createRotation);
        itemGo.transform.SetParent(gameObject.transform);
        itemPositionList.Add(createPosition);

    }

    //�������λ��
    private Vector3 CreateRandomPosition()
    {
        //��ֹ��׼����
        while (true)
        {
            //int index1 = Random.Range(0, iList1.Length - 1);
            //int index2 = Random.Range(0, iList2.Length - 1);
            Vector3 createPosition = new Vector3(Random.Range(-9, 10), Random.Range(-7, 8), 0);
            if (!HasThePosition(createPosition))
            {
                return createPosition;
            }
        }
    }
    private bool HasThePosition(Vector3 createPos)
    {
        for (int i = 0; i < itemPositionList.Count; i++)
        {
            if (createPos == itemPositionList[i])
            {
                return true;
            }
        }
        return false;
    }

    //�������˵ķ���
    private void CreateEnemy()
    {
        int num = Random.Range(0, 3);
        Vector3 EnemyPos = new Vector3();
        if (num == 0)
        {
            EnemyPos = new Vector3(-9, 7, 0);
        }
        else if (num == 1)
        {
            EnemyPos = new Vector3(9, 7, 0);
        }
        else
        {
            EnemyPos = new Vector3(9, 7, 0);
        }
        CreateItem(item[3], EnemyPos, Quaternion.identity);
    }


}