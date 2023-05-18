using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map8Player2 : MonoBehaviour
{
    Rigidbody2D rigid;
    public float maxSpeed;
    public float jumpPower;
    private bool isJump = true;
   // private bool isDie ;
    public Animator animator;
    public GameObject StartBtn;
    private GameObject missonControl;
     private Vector3 sitPlace;
    private GameObject panelController;
    private GameObject missionController;
    private ObjectSpawner objectSpawner;
    public GameObject gameController;

    void Awake()
    {
        missonControl = GameObject.Find("MissionController");
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.W) && isJump ) //�����̽��ٸ� ������, ĳ���Ͱ� ���� �ִٸ�
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJump = false;
        }
        //���⶧ �ӵ�
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
        //�ȱ�
        if (Input.GetButton("Left Right Arrow"))
        {
            animator.SetBool("IsWalking", true);
        }
        else animator.SetBool("IsWalking", false);


    }


    void FixedUpdate()
    {
        //�����϶� �ӵ�
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
        if (other.gameObject.tag == "Floor")
        {
            isJump = true;
            animator.SetBool("IsJumping", false);
        }
        //������ �Ա�
        if (other.gameObject.tag == "Leaf")
        {
            missonControl.GetComponent<MissonContorller>().leafCount++;
            Destroy(other.gameObject);
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
        //��ȭ ����
        if (other.gameObject.CompareTag("ChatNPC"))
        {
            other.GetComponent<Chat>().chatCanvus.SetActive(true);
            GameObject.Find("PanelController").GetComponent<BtnControl>().panelOn = true;
        }

    }

}

