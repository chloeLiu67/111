using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private SpriteRenderer sr;
    public GameObject explosionPrefab;
    public AudioClip dieAudio;
    public Sprite BrokenSprite;
    public bool isEnemyBase;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }


    public void Die()
    {
        if (sr.sprite != BrokenSprite)
        {
            sr.sprite = BrokenSprite;
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            PlayerManager.Instance.baseNum--;
        }
            
        
        if(!isEnemyBase)
        {
            PlayerManager.Instance.isDefeat = true;
        }
        //
        AudioSource.PlayClipAtPoint(dieAudio, transform.position);
    }
}
