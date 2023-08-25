using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BtnControl : MonoBehaviour
{
    public GameObject miniPanel;
    public GameObject RestartPanel;
    public GameObject Note;
    public GameObject Score;
    private GameObject player1;
    private Rigidbody2D player1Rb;
    private GameObject player2;
    private Rigidbody2D player2Rb;
    public bool panelOn = false;
    private Camera mainCamera; // Camera.main을 저장할 변수

    private void Awake()
    {
        // Awake 메서드에서 Camera.main을 가져옴
        mainCamera = Camera.main;
    }

    void Start()
    {
        Time.timeScale = 1;
        if (GameObject.Find("Player1"))
        {
            player1 = GameObject.Find("Player1");
            player1Rb = player1.GetComponent<Rigidbody2D>();
            player2 = GameObject.Find("Player2");
            player2Rb = player2.GetComponent<Rigidbody2D>();
        }
       
        if(miniPanel != null) 
        { 
            miniPanel.SetActive(false); 
        }
        if(GameObject.Find("RestartPanel") != null)
        {
            RestartPanel = GameObject.Find("RestartPanel");
            RestartPanel.SetActive(false);
        }

        if(GameObject.Find("Note") != null)
        {
            Note = GameObject.Find("Note");
            Note.SetActive(false);
        }
        if(GameObject.Find("Score") != null)
        {
            Score = GameObject.Find("Score");
            Score.SetActive(false);
        }
    }

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
            }
            
        }

    }
    public void StopBackgroundMusic()
    {
        // 현재 Scene에서 태그가 "MainCamera"인 카메라를 가져옴
        Camera mainCamera = Camera.main;

        // "MainCamera" 카메라에 붙어 있는 AudioSource를 가져와서 정지
        if (mainCamera != null)
        {
            AudioSource audioSource = mainCamera.GetComponent<AudioSource>();
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
    
    public void ClickRestartBtn()
    {
        RestartPanel.SetActive(true);
        Time.timeScale = 0;
        panelOn = false;
    }

    public void ClickStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }


    public void ClickMiniGameYes()
    {
        miniPanel.SetActive(false);
        Note.SetActive(true);
        Score.SetActive(true);
        StopBackgroundMusic();
        panelOn = true;
    }

     public void ClickMiniGameNo()
    {
        panelOn = false;
        miniPanel.SetActive(false);
    }

    public void ClickRestart()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(gameObject.scene.name);
        RestartPanel.SetActive(false);
        panelOn=false;
    }

    public void ClickExit()
    {
        Application.Quit();
    }
}
