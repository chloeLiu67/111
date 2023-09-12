using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float moveSpeed = 10;
    public bool isPlayerBullet;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * moveSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPlayerBullet) // 只有玩家的子弹才进行检测
        {
            if (collision.CompareTag("Enemy1") && tag == "Bullet1")
            {
                collision.SendMessage("Die");
                Destroy(gameObject);
            }
            else if (collision.CompareTag("Enemy2") && tag == "Bullet2")
            {
                collision.SendMessage("Die");
                Destroy(gameObject);
            }
            else if (collision.CompareTag("EnemyBase"))
            {
                // 仅玩家子弹对敌人基地生效
                collision.SendMessage("Die");
                Destroy(gameObject);
                //PlayerManager.Instance.baseNum--;
            }
            else if (collision.CompareTag("Heart"))
            {
                
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.CompareTag("Heart")){
                collision.SendMessage("Die");
                Destroy(gameObject);
            }
            else if (collision.CompareTag("Tank"))
            {
                collision.SendMessage("Die");
                Destroy(gameObject);
            }
        }
            switch (collision.tag)
        {
            case "Wall":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "Barrier":
                if (isPlayerBullet)
                {
                    collision.SendMessage("PlayAudio");
                }
                Destroy(gameObject);
                break;
            
            default:
                break;

        }
    }
}