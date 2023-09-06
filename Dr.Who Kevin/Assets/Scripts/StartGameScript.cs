using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    public string SceneName;
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR    //在编辑器模式下
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
