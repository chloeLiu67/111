using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [TextArea] public string DialogCount;
    [TextArea] public string[] str;
    public int Count;
    private int ClickNumber;
    public Text txt;
    public GameObject Module;
    private void Start()
    {
        Time.timeScale = 0;
        str = DialogCount.Split('\n');
        Count = str.Length;
    }

    public void ClickBtn()
    {

        if (ClickNumber >= Count - 1)
        {
            ClickPassBtn();
        }
        else
        {
            ClickNumber++;
            txt.text = str[ClickNumber];
        }
    }

    public void ClickPassBtn()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        //Module.SetActive(true);
    }
}
