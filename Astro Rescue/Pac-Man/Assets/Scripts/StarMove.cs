using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMove : MonoBehaviour
{
	public Transform[] waypionts;
	public float speed = 5f;
	private int index = 0;
	private int a = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
	private void FixedUpdate()
	{
		if (transform.position != waypionts[index].position)
		{
			Vector2 temp = Vector2.MoveTowards(transform.position, waypionts[index].position, speed);
			GetComponent<Rigidbody2D>().MovePosition(temp);
			
		}
		else
		{
			index = (index + 1) % waypionts.Length;
		}
		Vector2 dir = waypionts[index].position - transform.position;
	}
	// Update is called once per frame
	//void Update()
 //   {
        
 //   }
}
