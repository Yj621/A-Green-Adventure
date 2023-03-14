using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D rigid;
    public float maxSpeed;
    public float jumpPower;
    private bool isJump = true;
    private bool isDie = false;
    public Animator animator;
    public GameObject Target; //��ư�� ������ ����� ��ü
    public GameObject Btn; //��ư�� �������\


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && isJump /* && !Animation.GetBool("isJumping")*/) //�����̽��ٸ� ������, ĳ���Ͱ� ���� �ִٸ�
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJump = false;

        }
        //���⶧ �ӵ�
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
        //�����϶� �ӵ�
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed * (-1))
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
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
        }
        if (other.gameObject.tag == "Btn")
        {
            Target.SetActive(false);
            Btn.SetActive(false);
        }
        if (other.gameObject.tag == "Blind")
        {
            Destroy(other.gameObject);
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
