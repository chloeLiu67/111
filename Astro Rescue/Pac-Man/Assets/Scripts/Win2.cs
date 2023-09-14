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
		Debug.Log("切换场景");
	}
	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			// 从相机位置发射一条射线经过屏幕上的鼠标点击位置
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			// 声明一个射线碰撞信息类
			RaycastHit hit;

			// 进行碰撞检测
			bool res = Physics.Raycast(ray, out hit);

			// 如果产生了碰撞
			if (res)
			{
				Debug.Log("碰撞点：" + hit.point);
				Debug.Log("碰撞目标：" + hit.transform.name);
			}
		}

	}
}
