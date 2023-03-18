using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    Rigidbody2D rigid;
    public float maxSpeed;
    public float jumpPower;
    private bool isJump = true;
   // private bool isDie = false;
    private bool isSit=false;
    private Vector3 sitPlace;
    public Animator animator;
    public GameObject Target; //버튼을 누르면 사라질 객체
    public GameObject Btn; //버튼도 사라지게
    private GameObject miniPanel;
    private GameObject restartPanel;
    public GameObject Dialogues;
    public GameObject StartBtn;

    private void Start()
    {
        if (GameObject.Find("MiniGamePanel") != null)
        {
            miniPanel = GameObject.Find("MiniGamePanel");
            miniPanel.SetActive(false);
        }
        if(GameObject.Find("RestartPanel") != null)
        {
            restartPanel = GameObject.Find("RestartPanel");
            Debug.Log("찾음");
        }
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && isJump ) //스페이스바를 누르고, 캐릭터가 땅에 있다면
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJump = false;

        }
        //멈출때 속도
        if (Input.GetButtonDown("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("IsJumping", true);
        }
        else animator.SetBool("IsJumping", false);

        if (Input.GetButton("Horizontal"))
        {
            animator.SetBool("IsWalking", true);
        }
        else animator.SetBool("IsWalking", false);

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
        if (other.gameObject.tag == "Floor")
        {
            isJump = true;
            animator.SetBool("IsJumping", false);
        }
        if (other.gameObject.tag == "Obstacle")
        { 
            animator.SetBool("IsDie", true);
            restartPanel.SetActive(true);
        }
        if (other.gameObject.tag == "Blind")
        {
            Destroy(other.gameObject);

        }
        if (other.gameObject.tag == "Btn")
        {
            Btn.SetActive(false);
            Target.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Head")
        {
            isJump = true;
            animator.SetBool("IsJumping", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
      
        if (collision.gameObject.CompareTag("River"))
        {
            Dialogues.SetActive(true);
            StartBtn.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (collision.gameObject.CompareTag("Chair"))
            {
                Debug.Log("의자");
                if (isSit == false)
                {
                    sitPlace = collision.gameObject.transform.gameObject.GetComponentInChildren<Transform>().position;//new Vector3(collision.gameObject.transform.gameObject.GetComponentInChildren<Transform>().position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
                    gameObject.transform.position = sitPlace;
                    animator.SetBool("IsSit", true);
                    isSit = true;
                    Debug.Log("앉");
                }
                else
                {
                    animator.SetBool("IsSit", false);
                    isSit = false;
                    Debug.Log("섰");
                }
                

            }

            if (collision.gameObject.CompareTag("Npc6"))
            {
               if (miniPanel) miniPanel.SetActive(true);
            }
        }

    }
}


