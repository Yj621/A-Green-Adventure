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
    public bool isJump = true;
    private bool isSit = false;
    private GameObject chair;
    private GameObject chairChild;
    private GameObject miniPanel;
    private GameObject restartPanel;
    public GameObject Target; //��ư�� ������ ����� ��ü
    public GameObject Btn; //��ư�� �������
    private GameObject panelController;
    private GameObject missionController;

    public AudioSource JumpSound;
    public AudioSource WalkSound2;
    public AudioSource DieSound;
    public AudioSource BtnSound;
    public AudioSource BlindSound;
    private bool isJumping = false; // ���� ���� ���¸� �����ϴ� ����
    private bool isJumpSoundPlayed = false; // ���� �Ҹ��� ����Ǿ����� ���θ� ��Ÿ���� ����

    private void Start()
    {
        if (GameObject.Find("PanelController"))
        {
            panelController = GameObject.Find("PanelController");
        }
    
    }
   
    void Awake()
    {
        missionController = GameObject.Find("MissionController");
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //����
        if (Input.GetKeyDown(KeyCode.W)&& isJump && !isJumping)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJumping = true;
            animator.SetBool("IsJumping", true);

            if (!isJumpSoundPlayed) // ���� �Ҹ��� ������� ���� ��쿡�� ���
            {
                JumpSound.Play();
                isJumpSoundPlayed = true;
            }
        }
        else if(Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);
            isJumpSoundPlayed = false; // ���� Ű�� ���� �� ���� �Ҹ� ��� ���� �ʱ�ȭ
        }

        //���⶧ �ӵ�
        if (Input.GetButtonDown("Left Right Arrow"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        // �ȱ�
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
        //�����϶� �ӵ�
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
        //�ٴڿ� ������ ��
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Box")
        {
            isJump = true;
            isJumping = false;
            animator.SetBool("IsJumping", false);
        }
        // ��ֹ��� ��� ���� ��
        if (other.gameObject.CompareTag("Obstacle"))
        {
            animator.SetBool("IsDie", true);
            DieSound.Play();
            panelController.GetComponent<BtnControl>().RestartPanel.SetActive(true);
            panelController.GetComponent<BtnControl>().panelOn = true;
        }
        if (other.gameObject.CompareTag("Btn"))
        {
            BtnSound.Play();
            Btn.SetActive(false);
            Target.SetActive(false);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        // �ٴڿ� ������ ��
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJump = true;
            isJumping = false;
            animator.SetBool("IsJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // �ٴڿ��� ������ ��
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJump = false;
            isJumping = true;
            animator.SetBool("IsJumping", true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
     {
        //������ �Ծ��� ��
        if (other.gameObject.tag == "Leaf")
        {
            missionController.GetComponent<MissonContorller>().leafCount++;
            Destroy(other.gameObject);
        }
        //�Ӹ����
        if (other.gameObject.tag == "Head")
        {
            isJump = true;
            animator.SetBool("IsJumping", false);
            //isJumping = false; // �Ӹ��� ����� �� ���� ���¸� false�� ����
        }

        //��ȭ ����
        if (other.gameObject.CompareTag("ChatNPC"))
        {
            other.GetComponent<Chat>().chatCanvus.SetActive(true);
            GameObject.Find("PanelController").GetComponent<BtnControl>().panelOn = true;
        }
        
        if (other.gameObject.CompareTag("River"))
        {
            GameObject.Find("Canvas").transform.Find("Chat Back").gameObject.SetActive(true);
          //  StartBtn.SetActive(true);
        }
        if (other.gameObject.CompareTag("Npc6"))
        {
            if (panelController)
            {
                panelController.GetComponent<BtnControl>().panelOn = true;
                panelController.GetComponent<BtnControl>().miniPanel.SetActive(true);
            }
        }
        //��ȭ ���� NPC
        if (other.gameObject.CompareTag("ChatNPC"))
        {
            if (GameObject.Find("Canvas").transform.Find("Chat Back1"))
            {
                if (missionController.GetComponent<MissonContorller>().map5Clear == true)
                {
                    GameObject.Find("Canvas").transform.Find("Chat Back2").gameObject.SetActive(true);
                    missionController.GetComponent<MissonContorller>().dropLeaf = true;
                }
                else
                {
                    GameObject.Find("Canvas").transform.Find("Chat Back1").gameObject.SetActive(true);
                }

                GameObject.Find("PanelController").GetComponent<BtnControl>().panelOn = true;
            }
            else
            {
                GameObject.Find("Canvas").transform.Find("Chat Back").gameObject.SetActive(true);
                GameObject.Find("PanelController").GetComponent<BtnControl>().panelOn = true;
            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chair"))
        {
            // chair = collision.gameObject;
            // chair.transform.GetChild(2).gameObject.SetActive(true);
            // Debug.Log("����");
            if (Input.GetKeyDown(KeyCode.S))
            {
                //���� �ɱ�
                if (isSit == false)
                {
                    chair = collision.gameObject;
                    chairChild = chair.transform.GetChild(0).gameObject;
                    chairChild.SetActive(true);
                    gameObject.transform.position = new Vector3(chair.transform.position.x, chair.transform.position.y + 1f, chair.transform.position.z);
                    chair.GetComponent<BoxCollider2D>().isTrigger = false;
                    animator.SetBool("IsSit", true);
                    isSit = true;
                    Debug.Log("��");
                }
            }
        }
        if (collision.gameObject.CompareTag("ChairUp"))
        {
            //���ڿ��� �Ͼ��
            //Debug.Log("������");
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (isSit == true)
                {
                    chairChild.SetActive(false);
                    chair.GetComponent<BoxCollider2D>().isTrigger = true;
                    animator.SetBool("IsSit", false);
                    isSit = false;
                    Debug.Log("����");
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        // if (collision.gameObject.CompareTag("Chair"))
        // {
        //     chair = collision.gameObject;
        //     chair.transform.GetChild(2).gameObject.SetActive(false);
        // }
        if (collision.gameObject.CompareTag("River"))
        {
            GameObject.Find("Canvas").transform.Find("Chat Back").gameObject.SetActive(false);
            // StartBtn.SetActive(true);
        }
    }
}
