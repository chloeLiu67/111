using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win2 : MonoBehaviour
{
	public GameObject win;

	public GameObject Repetition;
	// Start is called before the first frame update
	void Start()
	{

	}

	public void A()
	{
		Debug.Log("�л�����");
	}
	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			// �����λ�÷���һ�����߾�����Ļ�ϵ������λ��
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			// ����һ��������ײ��Ϣ��
			RaycastHit hit;

			// ������ײ���
			bool res = Physics.Raycast(ray, out hit);

			// �����������ײ
			if (res)
			{
				Debug.Log("��ײ�㣺" + hit.point);
				Debug.Log("��ײĿ�꣺" + hit.transform.name);
			}
		}

	}
}
