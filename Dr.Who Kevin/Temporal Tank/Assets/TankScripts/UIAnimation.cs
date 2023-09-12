using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatUIAnimation : MonoBehaviour
{
    public AnimationCurve showCurve;
    public AnimationCurve hideCurve;
    public float animationSpeed;
    public GameObject DefeatPanel;
    public GameObject WinPanel;
    private bool hasShow;
    IEnumerator ShowPanel(GameObject gameObject)
    {
        float timer = 0;
        while(timer <= 1)
        {
            gameObject.transform.localScale = Vector3.one*showCurve.Evaluate(timer);
            timer += Time.deltaTime * animationSpeed;
            yield return null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.Instance.isDefeat && !hasShow)
        {
            StartCoroutine(ShowPanel(DefeatPanel));
            hasShow = true;
        }else if(PlayerManager.Instance.isWin && !hasShow)
        {
            StartCoroutine(ShowPanel(WinPanel));
            hasShow = true;
        }    
    }
}
