using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map8Player : MonoBehaviour
{
    Rigidbody2D rigid;
    public float maxSpeed;
    public float jumpPower;
    private bool isJump = true;
    //private bool isDie = false;
    public Animator animator;
    public GameObject StartBtn;
    private GameObject missonControl;
    void Awake()
    {
        missonControl = GameObject.Find("MissionController");
        rigid = GetComponent<Rigidbody2D>();
        GameObject.Find("Canvas").transform.Find("Chat Back").gameObject.SetActive(false);
    }
    void Update()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && isJump) //스페이스바를 누르고, 캐릭터가 땅에 있다면
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
        if (other.gameObject.tag == "Leaf")
        {
            missonControl.GetComponent<MissonContorller>().leafCount++;
            Destroy(other.gameObject);
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Head")
        {
            isJump = true;
            animator.SetBool("IsJumping", false);
        }

        if (other.gameObject.CompareTag("ChatNPC"))
        {
            other.GetComponent<Chat>().chatCanvus.SetActive(true);
            GameObject.Find("PanelController").GetComponent<BtnControl>().panelOn = true;
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
}

