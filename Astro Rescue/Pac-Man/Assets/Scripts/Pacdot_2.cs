using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pacdot_2 : MonoBehaviour
{
	//public bool isSuperPacdot = false;
	public GameObject Pacdot1;
	public GameObject Pacdot2;
	public GameObject Pacdot3;
	public GameObject[] StarMove;
	public Text[] Text;

	public GameObject Win;
	public GameObject Over;
	private int index = 0;
	private int count = 0;

	void TextActive(int s)
	{
		for (int i = 0; i < Text.Length; i++)
		{
			Text[i].gameObject.SetActive(false);

		}
		Text[s].gameObject.SetActive(true);

	}
	void OverCTR()
	{
		if (count == 5)
		{

			Over.gameObject.SetActive(true);

		}
	}
	private void OnCollisionEnter2D(Collision2D other)
	{
		switch (index)
		{
			case 0:
				if (other.gameObject.name == "Pacdot1")
				{

					other.gameObject.SetActive(false);

					TextActive(0);
					index++;
				}
				else
				{
					if (other.gameObject.name != "Maze")
					{

						count++;
						OverCTR();
					}

				}

				break;
			case 1:
				if (other.gameObject.name == "star1")
				{
					other.gameObject.SetActive(false);
					Pacdot2.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 240, 0);

					index++;
				}
				else
				{
					if (other.gameObject.name != "Maze")
					{

						count++;
						OverCTR();
					}

				}
				break;
			case 2:
				if (other.gameObject.name == "Pacdot2")
				{

					other.gameObject.SetActive(false);

					TextActive(1);
					index++;
				}
				else
				{
					if (other.gameObject.name != "Maze")
					{

						count++;
						OverCTR();
					}

				}
				break;
			case 3:
				if (other.gameObject.name == "star2")
				{
					other.gameObject.SetActive(false);
					Pacdot3.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 240, 0);

					index++;
				}
				else
				{
					if (other.gameObject.name != "Maze")
					{

						count++;
						OverCTR();
					}

				}
				break;
			case 4:
				if (other.gameObject.name == "Pacdot3")
				{

					other.gameObject.SetActive(false);
					TextActive(2);
					index++;
				}
				else
				{
					if (other.gameObject.name != "Maze")
					{

						count++;
						OverCTR();
					}

				}
				break;
			case 5:
				if (other.gameObject.name == "star3")
				{
					other.gameObject.SetActive(false);
					TextActive(3);

					index++;
				}
				else
				{
					if (other.gameObject.name != "Maze")
					{

						count++;
						OverCTR();
					}

				}
				break;
			case 6:
				if (other.gameObject.name == "star4")
				{
					other.gameObject.SetActive(false);
					TextActive(4);
					index++;
				}
				else
				{
					if (other.gameObject.name != "Maze")
					{

						count++;
						OverCTR();
					}

				}
				break;
			case 7:
				if (other.gameObject.name == "star5")
				{
					other.gameObject.SetActive(false);
					TextActive(5);
					index++;
				}
				else
				{
					if (other.gameObject.name != "Maze")
					{

						count++;
						OverCTR();
					}

				}
				break;
			case 8:
				if (other.gameObject.name == "star6")
				{
					other.gameObject.SetActive(false);
					Win.gameObject.SetActive(true);
					index++;
				}
				else
				{
					if (other.gameObject.name != "Maze")
					{

						count++;
						OverCTR();
					}

				}
				break;
		}
		Debug.Log("Ö´ÐÐÍê³É" + index);
		// if (other.gameObject.name == "Pacdot1")
		// {

		//     other.gameObject.SetActive(false);
		// }


	}
}
