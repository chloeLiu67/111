using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public Button pause_button;
    //public Button resume_button;
    public AnimationCurve showCurve;
    //public AnimationCurve hideCurve;
    public float animationSpeed;
    public GameObject panel;
    public bool isPause;

    private static MenuButton instance;
    public static MenuButton Instance
    {
        get
        {
            return instance;
        }

        set
        {
            instance = value;
        }
    }
    private void Awake()
    {
        instance = this;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        isPause = true;
    }

    IEnumerator ShowPanel(GameObject gameObject)
    {
        float timer = 0;
        while (timer <= 1)
        {
            gameObject.transform.localScale = Vector3.one * showCurve.Evaluate(timer);
            timer += Time.deltaTime * animationSpeed;
            yield return null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pause_button.onClick.AddListener(PauseGame);
        //resume_button.onClick.AddListener(ResumeGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPause)
        {
            StartCoroutine(ShowPanel(panel));
        }
    }

}
