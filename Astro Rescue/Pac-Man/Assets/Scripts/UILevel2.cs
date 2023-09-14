using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILevel2 : MonoBehaviour
{
	private Button nextlevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	public  void B_nextlevel()
	{
		SceneManager.LoadScene(1);
	}
	// Update is called once per frame
	void Update()
    {
        
    }
}
