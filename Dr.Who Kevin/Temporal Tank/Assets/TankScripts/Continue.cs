using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Continue : MonoBehaviour
{
    //public Button pause_button;
    public Button resume_button;

    public void ResumeGame()
    {
        Time.timeScale = 1;
        MenuButton.Instance.isPause = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        //pause_button.onClick.AddListener(PauseGame);
        resume_button.onClick.AddListener(ResumeGame);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
