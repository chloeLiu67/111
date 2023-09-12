using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManager : MonoBehaviour
{

    //属性值
    public int lifeValue = 3;
    public int playerScores = 0;
    public int baseNum = 4;
    public bool isDead;
    public bool isDefeat;
    public bool isWin;
    private float TimeVal;

    //引用
    public GameObject born;
    public Text playerScoreText;
    public Text playerLifeValueText;
    public Text EnemyBase;
    //public GameObject isDefeatUI;
    //public GameObject isWinUI;
    public AudioSource BackGroundMusic;
    public AudioClip[] BGM;

    //单例
    private static PlayerManager instance;
    public static PlayerManager Instance
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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Audio();

        if (isDefeat)
        {
            //isDefeatUI.SetActive(true);
            //Invoke("ReturnToTheMainMenu", 3);
            return;
        }
        if (isDead)
        {
            Recover();
        }
        if (isWin)
        {
            
            //isWinUI.SetActive(true);
            //Invoke("ReturnToTheMainMenu", 8);
            return;
        }
        playerScoreText.text = playerScores.ToString();
        playerLifeValueText.text = lifeValue.ToString();
        EnemyBase.text = baseNum.ToString();
        Win();
    }
    private void Recover()
    {
        if (lifeValue == 0)
        {
            //游戏失败
            isDefeat = true;
            //Invoke("ReturnToTheMainMenu", 3);
        }
        else
        {
            lifeValue--;
            if (lifeValue == 0)
            {
                Recover();
            }
            GameObject go = Instantiate(born, new Vector3(-2, -7, 0), Quaternion.identity);
            go.GetComponent<Born>().createPlayer = true;
            isDead = false;
        }
    }

    //ifWin
    private void Win()
    {

        if (playerScores >= 15 && baseNum == 0)
        {
            isWin = true;
        }
    }
    /*private void ReturnToTheMainMenu()
    {
        SceneManager.LoadScene(0);
    }*/

    //音乐
    private void Audio()
    {
        TimeVal += Time.deltaTime;
        if (TimeVal >= 2f)
        {           
            BackGroundMusic.clip = BGM[0];
            BackGroundMusic.loop = true;
            if (!BackGroundMusic.isPlaying)
            {
                BackGroundMusic.Play();
            }           
        }
    }

    /*public void CheckLevelNum()
    {
        int unlockBtnInt = PlayerPrefs.GetInt("unlockBtnInt");
        int levelNum = PlayerPrefs.GetInt("levelNum");
        if(levelNum>unlockBtnInt)
        {
            PlayerPrefs.SetInt("unlockBtnInt",unlockBtnInt+1);
        }
    }*/
}
