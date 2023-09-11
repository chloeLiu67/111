using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirshipMove : MonoBehaviour
{
	public float speed = 0.35f;
	private Vector2 dest = Vector2.zero;//目标位置
	public GameObject Object;
	private bool isMove = true;
	private void Start()
	{
		dest = transform.position;//获取初始坐标

	}

	private void FixedUpdate()//每一帧都调用一次
	{
		

		//必须先达到上一个dest的位置才可以发出新的目的地设置指令
		if ((Vector2)transform.position != dest && isMove == true)
		{
			//pacman移动方法
			//Vector2 temp = Vector2.MoveTowards(transform.position, dest, speed);//MoveTowards（Vector2 current，Vector2 target，float maxDistanceDelta）
			GetComponent<Rigidbody2D>().MovePosition(dest);//通过刚体组件来移动pacman
			//Attack();
			isMove = false;
			
		}
		if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && Valid(Vector2.up))
		{
			dest = (Vector2)transform.position + Vector2.up;
			//目标位置-当前位置 获得正负值判断移动的方向 控制动画
			Vector2 dir = dest - (Vector2)transform.position;

			isMove = true;

		}
		if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && Valid(Vector2.down))
		{
			dest = (Vector2)transform.position + Vector2.down;
			//目标位置-当前位置 获得正负值判断移动的方向 控制动画
			Vector2 dir = dest - (Vector2)transform.position;

			isMove = true;

		}
		if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && Valid(Vector2.left))
		{
			dest = (Vector2)transform.position + Vector2.left;
			//目标位置-当前位置 获得正负值判断移动的方向 控制动画
			Vector2 dir = dest - (Vector2)transform.position;

			isMove = true;

		}
		if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && Valid(Vector2.right))
		{
			dest = (Vector2)transform.position + Vector2.right;
			//目标位置-当前位置 获得正负值判断移动的方向 控制动画
			Vector2 dir = dest - (Vector2)transform.position;

			isMove = true;

		}
		

	}

	//通过射线检测的方式“目标位置”发出的射线到“当前位置”的collider是否为pacman自身的collider
	//如果是自身的collider那么返回为真，不是则为false。此方法目的是为了防止pacman卡死不动
	private bool Valid(Vector2 dir)
	{
		Vector2 pos = transform.position;
		RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
		return (hit.collider == Object.GetComponent<Collider2D>());
	}
	private void Attack()
	{
		dest = transform.position;
	}
}