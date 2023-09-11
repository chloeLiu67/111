using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class star1 : MonoBehaviour
{
	public Text Text;
	public GameObject StarMove;

	// Start is called before the first frame update
	void Start()
    {
        
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (Text.gameObject.activeSelf == true)
		{
			Debug.Log("Pacdot1" + "sss");

			if (collision.gameObject.name == "star1")
			{

				StarMove.SetActive(false);
				
				Debug.Log("Pacdot1" + "ssssss");

			}
		}
	}
		// Update is called once per frame
		void Update()
    {
		
	}
}
