using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map3Player2 : MonoBehaviour
{
    Rigidbody2D rigid;
    public Animator animator;
    public float maxSpeed;
    public float jumpPower;
    private bool isJump = true;
    // private bool isDie = false;
    private GameObject missionController;
    public bool isBtn2 = false;

    public GameObject RedObs; //버튼을 누르면 사라질 객체
    public GameObject RedBtn; //버튼도 사라지게

    public GameObject BlackObs;
    public GameObject BlackBtn;
    public GameObject BlackBtn2;

    public GameObject GreenObs;
    public GameObject GreenBtn;

    public GameObject map3;


    public AudioSource JumpSound;
    public AudioSource WalkSound;
    public AudioSource DieSound;
    public AudioSource BtnSound;
    public AudioSource BlindSound;
    public AudioSource LeafSound;
    private bool isJumping = false; // 이전 점프 상태를 저장하는 변수
    private bool isJumpSoundPlayed = false; // 점프 소리가 재생되었는지 여부를 나타내는 변수

    private void Start()
    {
        missionController = GameObject.Find("MissionController");
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W) && isJump && !isJumping)
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
        else if(Input.GetKeyDown(KeyCode.W))
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
        //걷기
        if (Input.GetButton("Left Right Arrow")&& !isJumping && !WalkSound.isPlaying)
        {
            WalkSound.Play();
            animator.SetBool("IsWalking", true);
        }
        else if(Input.GetButton("Left Right Arrow"))
        {
            WalkSound.Stop();
            animator.SetBool("IsWalking", false);
        }

    }


    void FixedUpdate()
    {
        //움직일때 속도
        float h = Input.GetAxisRaw("Left Right Arrow");
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
        if (other.gameObject.tag == "Floor")
        {
            isJump = true;
            animator.SetBool("IsJumping", false);
        }

        //장애물 닿아 죽기
        if (other.gameObject.tag == "Obstacle")
        {
            animator.SetBool("IsDie", true);
        }
        //빨강 버튼
        if (other.gameObject.tag == "RedBtn")
        {
            BtnSound.Play();
            RedObs.SetActive(false);
            RedBtn.SetActive(false);
        }
        //검은 버튼
        if (other.gameObject.tag == "BlackBtn")
        {
            BtnSound.Play();
            BlackObs.SetActive(false);
            BlackBtn.SetActive(false);
            BlackBtn2.SetActive(true);
        }
        //초록 버튼
        if (other.gameObject.tag == "GreenBtn")
        {
            BtnSound.Play();
            GreenObs.SetActive(false);
            GreenBtn.SetActive(false);
        }


        if (other.gameObject.tag == "Blind")
        {
            Destroy(other.gameObject);
            BlindSound.Play();
        }    

    }

    void OnCollisionStay2D(Collision2D other)
    {
        //버튼 누르기
        if (other.gameObject.tag == "Btn2")
        {
            isBtn2 = true;
            missionController.GetComponent<MissonContorller>().map3Btn2 = true;
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        missionController.GetComponent<MissonContorller>().map3Btn2 = false;
        isBtn2 = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Head")
        {
            isJump = true;
            animator.SetBool("IsJumping", false);
        }
        //나뭇잎 먹기
        if (other.gameObject.tag == "Leaf")
        {
            map3.GetComponent<Map3>().getLeaf = true;
            other.gameObject.SetActive(false);
            missionController.GetComponent<MissonContorller>().leafCount++;
        }  
    }
}