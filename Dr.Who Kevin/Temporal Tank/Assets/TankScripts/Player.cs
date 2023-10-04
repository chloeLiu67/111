using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //����ֵ
    public float moveSpeed = 3;
    private Vector3 bulletEulerAngles;
    public bool Movekey;
    private float TimeVal;
    private float defendTimeVal = 3;
    private bool isDefended = true;

    //����
    private SpriteRenderer sr;
    public Sprite[] tankSprite;//����
    public GameObject bulletPrefabLeft;
    public GameObject bulletPrefabRight;
    public GameObject explosionPrefab;
    public GameObject defendEffectPrefab;
    public AudioSource moveAudio;
    public AudioClip[] tankAudio;


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // ��ʼ���ӵ���ʼ�Ƕ�Ϊ̹�˳�ʼ����
        bulletEulerAngles = new Vector3(0, 0, 90);
    }

    // Update is called once per frame
    void Update()
    {
        //�Ƿ��޵�
        if (isDefended)
        {
            defendEffectPrefab.SetActive(true);
            defendTimeVal -= Time.deltaTime;
            if (defendTimeVal <= 0)
            {
                isDefended = false;
                defendEffectPrefab.SetActive(false);
            }
        }

        if (TimeVal >= 0.4f)
        {//���䲻ͬ�ӵ�
            if (Input.GetMouseButtonDown(0))// ���
            {
                Attack(bulletPrefabLeft);
                TimeVal = 0;
            }
            else if (Input.GetMouseButtonDown(1)) // �Ҽ�
            {
                Attack(bulletPrefabRight);
                TimeVal = 0;
            }
        }
        else
        {
            TimeVal += Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        if (PlayerManager.Instance.isDefeat)
        {
            return;
        }
        Move();       
    }

    //̹�˹���
    private void Attack(GameObject bulletPrefab)
    {
        //�ӵ������ĽǶ�=��ǰ̹�˽Ƕ�+�ӵ�Ӧ��ת�Ƕ�
        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEulerAngles));
    }


    //̹���ƶ�
    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        checklock();

        if (h * v == 0)//û��H��V�����ͻʱ
        {
            if (v != 0)
            {
                MoveV(v);
            }
            else
            {
                MoveH(h);
            }
        }
        else if (Movekey)//H,V��ͻʱ�����ƶ����жϺ󰴵ļ�
        {
            MoveH(h);
        }
        else
        {
            MoveV(v);
        }

    }


    private void checklock()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            Movekey = false;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            Movekey = true;
        }
    }

    private void MoveH(float h)
    {
        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (h < 0)
        {
            sr.sprite = tankSprite[3];
            bulletEulerAngles = new Vector3(0, 0, 180);
        }
        else if (h > 0)
        {
            sr.sprite = tankSprite[1];
            bulletEulerAngles = new Vector3(0, 0, 0);
        }
        AudioH(h);
    }


    private void MoveV(float v)
    {
        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (v < 0)
        {
            sr.sprite = tankSprite[2];
            bulletEulerAngles = new Vector3(0, 0, -90);
        }
        else if (v > 0)
        {
            sr.sprite = tankSprite[0];
            bulletEulerAngles = new Vector3(0, 0, 90);
        }
        AudioV(v);
    }

    private void AudioH(float h)
    {
        if (Mathf.Abs(h) > 0.05f)
        {
            moveAudio.clip = tankAudio[1];
            moveAudio.loop = true;
            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }
        }
        else
        {
            moveAudio.clip = tankAudio[0];
            moveAudio.loop = true;
            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }
        }
    }

    private void AudioV(float v)
    {
        if (Mathf.Abs(v) > 0.05f)
        {
            moveAudio.clip = tankAudio[1];
            moveAudio.loop = true;
            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }
        }
        else
        {
            moveAudio.clip = tankAudio[0];
            moveAudio.loop = true;
            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }
        }
    }


    //̹������
    private void Die()
    {
        if (isDefended)
        {
            return;
        }

        PlayerManager.Instance.isDead = true;

        //������ը��Ч
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        //����
        Destroy(gameObject);

    }
}
