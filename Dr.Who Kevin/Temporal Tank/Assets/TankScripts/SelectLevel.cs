using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    public GameObject selectPanel;
    Button[] levelBtns;
    public int unlockBtnInt;

    // Start is called before the first frame update
    void Start()
    {
        unlockBtnInt = PlayerPrefs.GetInt("unlockBtnInt");
        levelBtns = new Button[selectPanel.transform.childCount];

        for(int i = 0; i < selectPanel.transform.childCount; i++)
        {
            //selectPanel.transform.GetChild(i).GetComponent<Text>().text = (i+1).ToString();
            levelBtns[i] = selectPanel.transform.GetChild(i).GetComponent<Button>();
        }

        for(int i=0; i< levelBtns.Length; i++)
        {
            levelBtns[i].interactable = false;
        }

        for(int j=0;j<unlockBtnInt+1;j++)
        {
            levelBtns[j].interactable = true;
        }
        /*foreach(var levelBtn in levelBtns) 
        {
            levelBtn.interactable = false;

            levelBtn.onClick.AddListener(delegate () {
                Text text = levelBtn.gameObject.GetComponent<Text>();
                PlayerPrefs.SetInt("levelNum",int.Parse(text.text));
                //º”‘ÿ≥°æ∞
                SceneManager.LoadScene(1);
            });

        }*/

        /*for(int i = 0; i < unlockBtnInt + 1; i++)
        {
            levelBtns[i].interactable = true;
        }*/
    }

    public void qitBtn()
    {
        Application.Quit();
    }
    public void Jump()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
