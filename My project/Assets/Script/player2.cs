using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player2 : MonoBehaviour
{
    Rigidbody2D rigid;
    public Animator animator;
    public float maxSpeed;
    public float jumpPower;
    private bool isjump = true;
    private bool isSit = false;
    private GameObject chair;
    private GameObject chairChild;
    private GameObject miniPanel;
    private GameObject restartPanel;
    public GameObject Target; //버튼을 누르면 사라질 객체
    public GameObject Btn; //버튼도 사라지게
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
        }
        
    }
   
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.W) && isjump)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isjump = false;
        }

        //멈출때 속도
        if (Input.GetButtonDown("Left Right Arrow"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("IsJumping", true);
        }
        else animator.SetBool("IsJumping", false);

        if (Input.GetButton("Left Right Arrow"))
        {
            animator.SetBool("IsWalking", true);
        }
        else animator.SetBool("IsWalking", false);

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
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Box")
        {
            isjump = true;
        }
        if (other.gameObject.tag == "Obstacle")
        {
            animator.SetBool("IsDie", true);
            restartPanel.SetActive(true);
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
            isjump = true;
        }
        if (other.gameObject.CompareTag("River"))
        {
            GameObject.Find("Canvas").transform.Find("Chat Back").gameObject.SetActive(true);
            StartBtn.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Npc6"))
        {
            if (Input.GetKey(KeyCode.G))
            {
                if(miniPanel) miniPanel.SetActive(true);
            }
        }

        if (collision.gameObject.CompareTag("Chair"))
        {
            // Debug.Log("의자");
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (isSit == false)
                {
                    chair = collision.gameObject;
                    chairChild = chair.transform.GetChild(0).gameObject;
                    chairChild.SetActive(true);
                    gameObject.transform.position = new Vector3(chair.transform.position.x, chair.transform.position.y + 1f, chair.transform.position.z);
                    chair.GetComponent<BoxCollider2D>().isTrigger = false;
                    animator.SetBool("IsSit", true);
                    isSit = true;
                    Debug.Log("앉");
                }
            }
        }
        if (collision.gameObject.CompareTag("ChairUp"))
        {
            //Debug.Log("의자위");
            if (Input.GetKeyDown(KeyCode.S))
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
}
