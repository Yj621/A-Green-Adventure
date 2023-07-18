using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Map3Player : MonoBehaviour
{
    Rigidbody2D rigid;
    public float maxSpeed;
    public float jumpPower;
    private bool isJump = true;
    // private bool isDie = false;
    public bool isBtn1 = false;
    private GameObject missionController;
    public Animator animator;
    public GameObject BlueObs; 
    public GameObject BlueBtn; 
    public GameObject OrgBtn;
    public GameObject OrgBtn2;
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
        // 점프
        if (Input.GetKeyDown(KeyCode.UpArrow) && isJump && !isJumping)
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
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);
            isJumpSoundPlayed = false; // 점프 키를 놓을 때 점프 소리 재생 상태 초기화
        }
        
        // 멈출 때 속도
        if (Input.GetButtonDown("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        // 걷기
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
        float h = Input.GetAxisRaw("Horizontal");
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
        //장애물 닿아 죽을 때
        if (other.gameObject.tag == "Obstacle")
        {
            DieSound.Play();
            animator.SetBool("IsDie", true);
        }
        //파랑 버튼
        if (other.gameObject.tag == "BlueBtn")
        {
            BtnSound.Play();
            BlueObs.SetActive(false);
            BlueBtn.SetActive(false);
        }
        //주황버튼
        if (other.gameObject.tag == "OrBtn")
        {
            OrgBtn.SetActive(false);
            BtnSound.Play();
            GameObject.Find("Orange").transform.Find("Org").gameObject.SetActive(true);
            OrgBtn2.SetActive(true);
        }

        if (other.gameObject.tag == "Blind")
        {
            Destroy(other.gameObject);
            BlindSound.Play();
        }  
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Head")
        {
            isJump = true;
            animator.SetBool("IsJumping", false);
        }
        //나뭇잎 먹을 때
        if (other.gameObject.tag == "Leaf")
        {
            LeafSound.Play();
            map3.GetComponent<Map3>().getLeaf = true;
            missionController.GetComponent<MissonContorller>().leafCount++;
            other.gameObject.SetActive(false);
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        //버튼 누를 때
        if (other.gameObject.tag == "Btn1")
        {
            isBtn1 = true;
            // BtnSound.Play();
            missionController.GetComponent<MissonContorller>().map3Btn1 = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        isBtn1 = false;
        missionController.GetComponent<MissonContorller>().map3Btn1 = false;
    }
}
