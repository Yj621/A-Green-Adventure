using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    Rigidbody2D rigid;
    public float maxSpeed;
    public float jumpPower;
    public bool isJump = true;
    private bool isSit = false;
    private GameObject chair;
    private GameObject chairChild;
    // private bool isDie = false;
    private Vector3 sitPlace;
    public Animator animator;
    public GameObject Target; //버튼을 누르면 사라질 객체
    public GameObject Btn; //버튼도 사라지게
    private GameObject panelController;
    private GameObject missionController;

    public AudioSource JumpSound;
    public AudioSource WalkSound;
    public AudioSource DieSound;
    public AudioSource BtnSound;
    public AudioSource BlindSound;
    private bool isJumping = false; // 이전 점프 상태를 저장하는 변수
    private bool isJumpSoundPlayed = false; // 점프 소리가 재생되었는지 여부를 나타내는 변수

    private void Start()
    {
        if (GameObject.Find("PanelController"))
        {
            panelController = GameObject.Find("PanelController");
        }
        missionController = GameObject.Find("MissionController");
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
        if (Input.GetButton("Horizontal") && !isJumping || !WalkSound.isPlaying)
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
        // 움직일 때 속도
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        if (rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (rigid.velocity.x < -maxSpeed)
        {
            rigid.velocity = new Vector2(-maxSpeed, rigid.velocity.y);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // 바닥에 서있을 때
        if (other.gameObject.CompareTag("Floor") || other.gameObject.CompareTag("Box"))
        {
            isJump = true;
            isJumping = false;
            animator.SetBool("IsJumping", false);
        }
        // 장애물에 닿아 죽을 때
        if (other.gameObject.CompareTag("Obstacle"))
        {
            animator.SetBool("IsDie", true);
            DieSound.Play();
            panelController.GetComponent<BtnControl>().RestartPanel.SetActive(true);
            panelController.GetComponent<BtnControl>().panelOn = true;
        }
        if (other.gameObject.CompareTag("Blind"))
        {
            Destroy(other.gameObject);
            BlindSound.Play();
        }
        // 버튼 누를 때
        if (other.gameObject.CompareTag("Btn"))
        {
            BtnSound.Play();
            Btn.SetActive(false);
            Target.SetActive(false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // 바닥에 서있을 때
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJump = true;
            isJumping = false;
            animator.SetBool("IsJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // 바닥에서 떨어질 때
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJump = false;
            isJumping = true;
            animator.SetBool("IsJumping", true);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //나뭇잎 먹을 때
        if (other.gameObject.tag == "Leaf")
        {
            missionController.GetComponent<MissonContorller>().leafCount++;
            Destroy(other.gameObject);
            missionController.GetComponent<MissonContorller>().dropLeaf = false;
        }
        //머리 밟기
        if (other.gameObject.tag == "Head")
        {
            isJump = true;
            JumpSound.Play();
            animator.SetBool("IsJumping", false);
        }
        //River에 갔을 경우
        if (other.gameObject.CompareTag("River"))
        {
            GameObject.Find("Canvas").transform.Find("Chat Back").gameObject.SetActive(true);
        }
       
    }
  
  
    private void OnTriggerStay2D(Collider2D collision)
    {
      
        if (collision.gameObject.CompareTag("Chair"))
        {
            chair = collision.gameObject;
            chair.transform.GetChild(1).gameObject.SetActive(true);
            // Debug.Log("의자");
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                //의자 앉기
                if (isSit == false)
                {                
                    chairChild = chair.transform.GetChild(0).gameObject;
                    chairChild.SetActive(true);
                    gameObject.transform.position = new Vector3(chair.transform.position.x, chair.transform.position.y + 1f, chair.transform.position.z);
                    rigid.constraints = RigidbodyConstraints2D.FreezeAll;
                    chair.GetComponent<BoxCollider2D>().isTrigger = false;
                    animator.SetBool("IsSit", true);
                    isSit = true;
                    
                    Debug.Log("앉기");
                    
                }
            }
        }
        if (collision.gameObject.CompareTag("ChairUp"))
        {
            //의자에서 일어나기
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (isSit == true)
                {
                   
                    chairChild.SetActive(false);
                    chair.GetComponent<BoxCollider2D>().isTrigger = true;
                    animator.SetBool("IsSit", false);
                    isSit = false;
                   
                    Debug.Log("서기");
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Chair"))
        {
            chair = collision.gameObject;
            chair.transform.GetChild(1).gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("River"))
        {
            GameObject.Find("Canvas").transform.Find("Chat Back").gameObject.SetActive(false);
        }
                //대화 시작
        if (collision.gameObject.CompareTag("ChatNPC"))
        {
            collision.GetComponent<Chat>().chatCanvus.SetActive(true);
            GameObject.Find("PanelController").GetComponent<BtnControl>().panelOn = true;
        }
        
    }
}