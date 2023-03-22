using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BtnControl : MonoBehaviour
{
    private GameObject miniPanel;
    private GameObject RestartPanel;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("MiniGamePanel") != null)
        {
            miniPanel = GameObject.Find("MiniGamePanel");
            miniPanel.SetActive(false);
        }
        if(GameObject.Find("RestartPanel") != null)
        {
            RestartPanel = GameObject.Find("RestartPanel");
            RestartPanel.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
       miniPanel.SetActive(false);
    }

    public void ClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        RestartPanel.SetActive(false);
    }

    public void ClickExit()
    {
        Application.Quit();
    }
}
