using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILevel1 : MonoBehaviour
{

	public GameObject gb;
	public GameObject level1;
	public GameObject level2;
	// Start is called before the first frame update
	void Start()
    {
        
    }
	public void B_nextlevel()
	{
		gb.gameObject.SetActive(true);
		level1.gameObject.SetActive(false);
		level2.gameObject.SetActive(false);
	}
	// Update is called once per frame
	void Update()
    {
        
    }
}
