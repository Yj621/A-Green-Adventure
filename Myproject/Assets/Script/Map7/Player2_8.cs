using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_8 : MonoBehaviour
{
    Rigidbody2D rigid;
    public float maxSpeed;
    public float jumpPower;
    public bool isJump = true;
    private Vector3 sitPlace;
    public Animator animator;
    private GameObject panelController;
    private GameObject missionController;
    private ObjectSpawner objectSpawner;
    public GameObject gameController;

    public AudioSource JumpSound;
    public AudioSource WalkSound2;
    public AudioSource DieSound;
    public AudioSource BtnSound;
    public AudioSource BossGetSound;
    private bool isJumping = false; // 이전 점프 상태를 저장하는 변수
    private bool isJumpSoundPlayed = false; // 점프 소리가 재생되었는지 여부를 나타내는 변수

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
        //점프
        if (Input.GetKeyDown(KeyCode.W)&& isJump && !isJumping)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJumping = true;
            animator.SetBool("IsJumping", true);

            if (!isJumpSoundPlayed) // 점프 소리가 재생되지 않은 경우에만 재생
            {
                JumpSound.Play();
                isJumpSoundPlayed = true;
            }
        }
        else if(Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);
            isJumpSoundPlayed = false; // 점프 키를 놓을 때 점프 소리 재생 상태 초기화
        }

        //멈출때 속도
        if (Input.GetButtonDown("Left Right Arrow"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        // 걷기
        if (Input.GetButton("Left Right Arrow") && !isJumping && !WalkSound2.isPlaying)
        {
            WalkSound2.Play();
            animator.SetBool("IsWalking", true);
        }
        else if (!Input.GetButton("Left Right Arrow"))
        {
            WalkSound2.Stop();
            animator.SetBool("IsWalking", false);
        }

    }


    void FixedUpdate()
    {
        //움직일때 속도
        float h =  Input.GetAxisRaw("Left Right Arrow");
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
            gameController.GetComponent<BossGameContorl>().player2Touch = "clover";
            BossGetSound.Play();
            Destroy(other.gameObject);
            gameController.GetComponent<BossGameContorl>().BossHpBar();
            gameController.GetComponent<BossGameContorl>().player2HpContorl();
        }
        else if (other.gameObject.CompareTag("heart"))
        {
            gameController.GetComponent<BossGameContorl>().player2Touch = "heart";
            BossGetSound.Play();
            Destroy(other.gameObject);
            gameController.GetComponent<BossGameContorl>().BossHpBar();
            gameController.GetComponent<BossGameContorl>().player2HpContorl();
        }
        else if (other.gameObject.CompareTag("diamond"))
        {
            gameController.GetComponent<BossGameContorl>().player2Touch = "diamond";
            BossGetSound.Play();
            Destroy(other.gameObject);
            gameController.GetComponent<BossGameContorl>().BossHpBar();
            gameController.GetComponent<BossGameContorl>().player2HpContorl();
        }
        else if (other.gameObject.CompareTag("spade"))
        {
            gameController.GetComponent<BossGameContorl>().player2Touch = "spade";
            BossGetSound.Play();
            Destroy(other.gameObject);
            gameController.GetComponent<BossGameContorl>().BossHpBar();
            gameController.GetComponent<BossGameContorl>().player2HpContorl();
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


