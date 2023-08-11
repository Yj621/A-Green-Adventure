using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_8 : MonoBehaviour
{
    Rigidbody2D rigid;
    public float maxSpeed;
    public float jumpPower;
    public bool isJump = true;
    public GameObject gameController;
    private Vector3 sitPlace;
    public Animator animator;
    private GameObject panelController;
    private GameObject missionController;
    private ObjectSpawner objectSpawner;

    public AudioSource JumpSound;
    public AudioSource WalkSound;
    public AudioSource DieSound;
    public AudioSource BtnSound;
    public AudioSource BossGetSound;
    private bool isJumping = false;
    private bool isJumpSoundPlayed = false; 
 
    void Start()
    {
        gameController = GameObject.Find("GameController");
        objectSpawner = GameObject.FindObjectOfType<ObjectSpawner>();
        if (GameObject.Find("PanelController"))
        {
            panelController = GameObject.Find("PanelController");
        }
        missionController = GameObject.Find("MissionController");
        
        
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // ����
        if (Input.GetKeyDown(KeyCode.UpArrow) && isJump && !isJumping)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJumping = true;
            animator.SetBool("IsJumping", true);

            if (!isJumpSoundPlayed) // ���� �Ҹ��� ������� ���� ��쿡�� ���
            {
                JumpSound.Play();
                isJumpSoundPlayed = true;
            }
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);
            isJumpSoundPlayed = false; // ���� Ű�� ���� �� ���� �Ҹ� ��� ���� �ʱ�ȭ
        }
        
        // ���� �� �ӵ�
        if (Input.GetButtonDown("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        // �ȱ�
        if (Input.GetButton("Horizontal") && !isJumping && !WalkSound.isPlaying)
        {
            WalkSound.Play();
            animator.SetBool("IsWalking", true);
        }
        else if (!Input.GetButton("Horizontal"))
        {
            WalkSound.Stop();
            animator.SetBool("IsWalking", false);
        }
    }


    void FixedUpdate()
    {
        //움직일때 속도
        float h =  Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (rigid.velocity.x < maxSpeed * (-1))
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("clover"))
        {
            //부딫힌 오브젝트 태그 저장
            gameController.GetComponent<BossGameContorl>().player1Touch = other.gameObject.tag;
            BossGetSound.Play();
            //부딪히면 삭제
            Destroy(other.gameObject);
            //보스 체력 깎는 함수
            gameController.GetComponent<BossGameContorl>().BossHpBar();
            //플레이어 hp를  UI에 적용
            gameController.GetComponent<BossGameContorl>().player1HpContorl();
        }
        else if (other.gameObject.CompareTag("heart"))
        {
            gameController.GetComponent<BossGameContorl>().player1Touch = other.gameObject.tag;
            BossGetSound.Play();            
            Destroy(other.gameObject);
            gameController.GetComponent<BossGameContorl>().BossHpBar();
            gameController.GetComponent<BossGameContorl>().player1HpContorl();
        }
        else if (other.gameObject.CompareTag("diamond"))
        {
            gameController.GetComponent<BossGameContorl>().player1Touch = other.gameObject.tag;
            BossGetSound.Play(); 
            Destroy(other.gameObject);
            gameController.GetComponent<BossGameContorl>().BossHpBar();
            gameController.GetComponent<BossGameContorl>().player1HpContorl();
        }
        else if (other.gameObject.CompareTag("spade"))
        {
            gameController.GetComponent<BossGameContorl>().player1Touch = other.gameObject.tag;
            BossGetSound.Play(); 
            Destroy(other.gameObject);
            gameController.GetComponent<BossGameContorl>().BossHpBar();
            gameController.GetComponent<BossGameContorl>().player1HpContorl();
        }
    }
    
 
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = true;
            animator.SetBool("IsJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
            animator.SetBool("IsJumping", true);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Head")
        {
            isJump = true;
            animator.SetBool("IsJumping", false);
        }
        if (other.gameObject.CompareTag("ChatNPC") && missionController.GetComponent<MissonContorller>().missonNum != 10)
        {
            other.GetComponent<Chat>().chatCanvus.SetActive(true);
            GameObject.Find("PanelController").GetComponent<BtnControl>().panelOn = true;
        }
        if (other.gameObject.tag == "Leaf")
        {
            missionController.GetComponent<MissonContorller>().leafCount=3;
            gameController.GetComponent<BossGameContorl>().PlayerWin = false;
            other.gameObject.SetActive(false);
        }
    }

}


