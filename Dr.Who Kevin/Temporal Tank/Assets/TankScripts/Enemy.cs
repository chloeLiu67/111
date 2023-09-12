using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //属性值
    public float moveSpeed = 3;
    private Vector3 bulletEulerAngles;
    public bool Movekey;
    private float v = -1;
    private float h = 0;


    //引用
    private SpriteRenderer sr;
    public Sprite[] tankSprite;//方向
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;

    //计时器
    private float TimeVal;
    private float timeValChangeDirection = 0;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }

    private void FixedUpdate()
    {
        Move();
        //攻击时间间隔
        if (TimeVal >= 4f)
        {
            Attack();
        }
        else
        {
            TimeVal += Time.deltaTime;
        }

    }

    //坦克攻击
    private void Attack()
    {

        //子弹产生的角度=当前坦克角度+子弹应旋转角度
        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEulerAngles));
        TimeVal = 0;

    }


    //坦克移动
    private void Move()
    {
        if (timeValChangeDirection >= 4)
        {
            int num = Random.Range(0, 17);
            if (num >= 12)
            {
                v = -1;
                h = 0;
            }
            else if (num >= 0 && num < 4)
            {
                v = 1;
                h = 0;
            }
            else if (num >= 4 && num < 8)
            {
                h = -1;
                v = 0;
            }
            else if (num >= 8 && num < 12)
            {
                h = 1;
                v = 0;
            }

            timeValChangeDirection = 0;
        }
        else
        {
            timeValChangeDirection += Time.fixedDeltaTime;
        }


        if (v != 0)
        {
            MoveV(v);
        }
        else
        {
            MoveH(h);
        }

    }



    private void MoveH(float h)
    {
        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (h < 0)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = true; // 水平翻转
            bulletEulerAngles = new Vector3(0, 0, 180);
            
        }
        else if (h > 0)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = false; // 水平翻转
            bulletEulerAngles = new Vector3(0, 0, 0);
        }
    }


    private void MoveV(float v)
    {
        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (v < 0)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = true; // 水平翻转
            bulletEulerAngles = new Vector3(0, 0, -90);
            
        }
        else if (v > 0)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = false; // 水平翻转
            
            bulletEulerAngles = new Vector3(0, 0, 90);
        }
    }

    //坦克死亡
    private void Die()
    {
        PlayerManager.Instance.playerScores++;
        //产生爆炸特效
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        //死亡
        Destroy(gameObject);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy1" || collision.gameObject.tag == "Enemy2" || collision.gameObject.tag == "River" || collision.gameObject.tag == "Barrier" || collision.gameObject.tag == "EnemyBase1" || collision.gameObject.tag == "EnemyBase2")
        {
            timeValChangeDirection = 0;
            if (h != 0)
            {
                if (h < 0)
                {
                    h = Random.Range(0, 2);
                    if (h == 0)
                    {
                        v = Random.value < 0.5f ? -1f : 1f;
                    }
                }
                if (h > 0)
                {
                    h = Random.Range(-1, 1);
                    if (h == 0)
                    {
                        v = Random.value < 0.5f ? -1f : 1f;
                    }
                }
            }
            if (v != 0)
            {
                if (v < 0)
                {
                    v = Random.Range(0, 2);
                    if (v == 0)
                    {
                        h = Random.value < 0.5f ? -1f : 1f;
                    }
                }
                if (v > 0)
                {
                    v = Random.Range(-1, 1);
                    if (v == 0)
                    {
                        h = Random.value < 0.5f ? -1f : 1f;
                    }
                }
            }
        }
    }
}
