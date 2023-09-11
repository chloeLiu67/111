using UnityEngine;
using UnityEngine.UI;

public class Pacdot : MonoBehaviour
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
        if (count == 3)
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
        Debug.Log("执行完成" + index);
        // if (other.gameObject.name == "Pacdot1")
        // {

        //     other.gameObject.SetActive(false);
        // }


    }
    // private void OnTriggerEnter2D(Collider2D collision)
    // {

    //     if (collision.gameObject.name == "Pacdot1")
    //     {

    //         Debug.Log(123);
    //         //Destroy(Pacdot1.gameObject);
    //         Pacdot1.SetActive(false);

    //         Pacdot2.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 240, 0);
    //         if (Pacdot1.gameObject.activeSelf == false)
    //         {

    //             Debug.Log("Pacdot1" + index);
    //             Text[0].gameObject.SetActive(true);
    //             index = index + 1;


    //         }


    //     }


    //     else if (index == 1)
    //     {
    //         if (collision.gameObject.name == "star1")
    //         {
    //             StarMove[1].SetActive(false);
    //             index = index + 1;
    //         }


    //     }
    //     else if (index == 2)
    //     {
    //         if (collision.gameObject.name == "Pacdot2")
    //         {
    //             //Destroy(Pacdot2.gameObject);
    //             Pacdot2.SetActive(false);
    //             Pacdot3.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 240, 0);


    //             if (Pacdot2.gameObject.isStatic == false)
    //             {
    //                 Debug.Log("Pacdot2" + index);
    //                 Text[1].gameObject.SetActive(true);
    //                 index = index + 1;


    //             }
    //         }
    //     }
    //     else if (index == 3)
    //     {
    //         if (collision.gameObject.name == "star2")
    //         {
    //             StarMove[1].SetActive(false);
    //             index = index + 1;
    //         }
    //     }

    //     else if (index == 4)
    //     {
    //         if (collision.gameObject.name == "Pacdot3")
    //         {
    //             Debug.Log(456);
    //             Pacdot3.SetActive(false);
    //             //Destroy(Pacdot3.gameObject);
    //             if (Pacdot3.gameObject.isStatic == false)
    //             {

    //                 Debug.Log("Pacdot3" + index);
    //                 Text[2].gameObject.SetActive(true);
    //                 index = index + 1;

    //             }



    //         }

    //     }
    //     else if (index == 5)
    //     {
    //         if (collision.gameObject.name == "star3")
    //         {
    //             StarMove[2].SetActive(false);
    //             Text[3].gameObject.SetActive(true);
    //             index = index + 1;
    //         }
    //     }
    //     else if (index == 6)
    //     {
    //         if (collision.gameObject.name == "star4")
    //         {
    //             StarMove[3].SetActive(false);
    //             index = index + 1;
    //         }
    //         if (index == 7)
    //         {


    //             Win.gameObject.SetActive(true);


    //         }

    //     }
    //else
    //{
    //	count = count - 1;
    //	if (count <= -3)
    //	{
    //		Over.gameObject.SetActive(true);
    //	}

    //}


    // }


}
