using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaLogScripte : MonoBehaviour
{
    [TextArea] public string DialogCount;
    [TextArea] public string[] str;
    public int Count;
    private int ClickNumber;
    public Text txt;
    public GameObject Module;
    private void Start()
    {
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
        gameObject.SetActive(false);
        Module.SetActive(true);
    }
}