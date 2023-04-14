using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Chat : MonoBehaviour
{
    List<string> chat2 = new List<string>() { "안녕?", "숲이 참 아름답지?", "하지만 강물이 말라버렸어", "이대로면 나무들도 말라버릴거야!", "강물이 막힌 원인을 찾아주겠어?" };
    List<string> chat5_1 = new List<string>() { "안녕?", "우리집에 온걸 환영해.", "집이 지저분하다고?", "전기세가 너무 많이 나와서\n 모든 의욕을 잃었는걸?" };
    List<string> chat5_2 = new List<string>() { "집이 깨끗해졌네!","에어컨도 꺼졌고!","고마워!\n 여기 보답이야." };
    List<string> currentChat = new List<string>();
    private TextMeshProUGUI myTextMeshProUGUI;
    private int SentanceNum = 0;
    private GameObject missonController;
    public GameObject chatCanvus;

    // Start is called before the first frame update

    void Start()
    {
        missonController = GameObject.Find("MissionController");
        myTextMeshProUGUI = chatCanvus.gameObject.transform.GetChild(1).GetComponent< TextMeshProUGUI >();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.GetChild(0).CompareTag("ChatNPC2"))
        {
            currentChat = chat2;
        }
        else if (gameObject.transform.GetChild(0).CompareTag("ChatNPC5"))
        {
            if (missonController.GetComponent<MissonContorller>().map5Clear == false)
            {
                currentChat = chat5_1;
            }
            else
            {
                currentChat = chat5_2;
                missonController.GetComponent<MissonContorller>().dropLeaf = true;
            }
        }
        if (SentanceNum >= currentChat.Count)
        {
            chatCanvus.SetActive(false);
            GameObject.Find("PanelController").GetComponent<BtnControl>().panelOn = false;
        }
        else
        {
            myTextMeshProUGUI.text = currentChat[SentanceNum];
        }
    }

    public void ClicNext()
    {
        Debug.Log("Click");
        SentanceNum++;
    }
}
