using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BtnControl : MonoBehaviour
{
    public GameObject miniPanel;
    public GameObject RestartPanel;
    private GameObject player1;
    private Rigidbody2D player1Rb;
    private GameObject player2;
    private Rigidbody2D player2Rb;
    public bool panelOn = false;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Player1"))
        {
            player1 = GameObject.Find("Player1");
            player1Rb = player1.GetComponent<Rigidbody2D>();
            player2 = GameObject.Find("Player2");
            player2Rb = player2.GetComponent<Rigidbody2D>();
        }
       
        if(miniPanel != null) { miniPanel.SetActive(false); }
        if(GameObject.Find("RestartPanel") != null)
        {
            RestartPanel = GameObject.Find("RestartPanel");
            RestartPanel.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (panelOn == true)
        {
            if (player1)
            {
                player1Rb.constraints = RigidbodyConstraints2D.FreezeAll;
                player2Rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
         
        }
        else
        {
            if (player1) {
                player1Rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                player2Rb.constraints = RigidbodyConstraints2D.FreezeRotation;
               // player2.GetComponent<player2>().isjump = true;
               // player1.GetComponent<player>().isJump = true;    
            }
            
        }

    }

    public void ClickRestartBtn()
    {
        RestartPanel.SetActive(true);
        panelOn = false;
    }

    public void ClickStart()
    {
        SceneManager.LoadScene(1);
    }


    public void ClickMiniGameYes()
    {
        //리듬게임 시작
    }

     public void ClickMiniGameNo()
    {
        panelOn = false;
        miniPanel.SetActive(false);
    }

    public void ClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        RestartPanel.SetActive(false);
        panelOn=false;
    }

    public void ClickExit()
    {
        Application.Quit();
    }
}
