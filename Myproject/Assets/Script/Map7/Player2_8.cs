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
        //Jump
        if (Input.GetKeyDown(KeyCode.W) && isJump ) //스페이스바를 누르고, 캐릭터가 땅에 있다면
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJump = false;
        }
        //멈출때 속도
        if (Input.GetButtonDown("Left Right Arrow"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        //Jump
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("IsJumping", true);
        }
        else animator.SetBool("IsJumping", false);
        //걷기
        if (Input.GetButton("Left Right Arrow"))
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
        if (other.gameObject.CompareTag("clover"))
        {
            gameController.GetComponent<BossGameContorl>().player2Touch = "clover";
            Destroy(other.gameObject);
            gameController.GetComponent<BossGameContorl>().BossHpBar();
            gameController.GetComponent<BossGameContorl>().player2HpContorl();
        }
        else if (other.gameObject.CompareTag("heart"))
        {
            gameController.GetComponent<BossGameContorl>().player2Touch = "heart";
            Destroy(other.gameObject);
            gameController.GetComponent<BossGameContorl>().BossHpBar();
            gameController.GetComponent<BossGameContorl>().player2HpContorl();
        }
        else if (other.gameObject.CompareTag("diamond"))
        {
            gameController.GetComponent<BossGameContorl>().player2Touch = "diamond";
            Destroy(other.gameObject);
            gameController.GetComponent<BossGameContorl>().BossHpBar();
            gameController.GetComponent<BossGameContorl>().player2HpContorl();
        }
        else if (other.gameObject.CompareTag("spade"))
        {
            gameController.GetComponent<BossGameContorl>().player2Touch = "spade";
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
    }

}


