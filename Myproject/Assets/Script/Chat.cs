using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Chat : MonoBehaviour
{
  List<string> chat2 = new List<string>() { "안녕?", "숲이 참 아름답지?", "하지만 강물이 말라버렸어", "이대로면 나무들도 말라버릴거야!", "강물이 막힌 원인을 찾아주겠어?" };
    List<string> chat4 = new List<string>() { "도시에 온걸 환영해", "이 도시는 두번째로 만들어진 도시인거 알아?", "조금 더 가면 옛날 도시가 나와", "우리 형이 살고 있는 곳이지", "가서 안부 전해줄래?" };
    List<string> chat5_1 = new List<string>() { "안녕?", "우리집에 온걸 환영해.", "집이 지저분하다고?", "전기세가 너무 많이 나와서\n 모든 의욕을 잃었는걸?" };
    // List<string> chat5_2 = new List<string>() { "집이 깨끗해졌네!","에어컨도 꺼졌고!","고마워!\n 여기 보답이야." };
    List<string> chat8_1 = new List<string>() { "내 동생?", "맞아, 동생은 도시에 살고 있어", "안부 전해줘서 고마워", "여기는 이렇게 황폐하고 오염되었지만", "옆 도시는 정말 번화가라던데", "나 대신 구경해보고 얘기해 줄래?" };
    List<string> chat8_2 = new List<string>() { "고마워, 이건 내 선물이야" };    List<string> currentChat = new List<string>();
    List<string> chat7 = new List<string>() { "여긴 어떻게 들어온거지?", "나를 쓰러뜨릴 수 있을 것 같나?", "그렇다면 한 번 덤벼봐라!" };
    private TextMeshProUGUI myTextMeshProUGUI;
    private int SentanceNum = 0;
    private GameObject missonController;
    public GameObject chatCanvus;
    int i = 0;
    int j = 0;
    void Start()
    {
        missonController = GameObject.Find("MissionController");
        myTextMeshProUGUI = chatCanvus.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (gameObject.transform.GetChild(0).CompareTag("ChatNPC2"))
        {
            currentChat = chat2;
        }
        else if (gameObject.transform.GetChild(0).CompareTag("ChatNPC4"))
        {
            currentChat = chat4;
        }
        else if (gameObject.transform.GetChild(0).CompareTag("ChatNPC7"))
        {
            currentChat = chat7;
        }
        else if (gameObject.transform.GetChild(0).CompareTag("ChatNPC5"))
        {
            if (missonController.GetComponent<MissonContorller>().map5Clear == false)
            {
                currentChat = chat5_1;
            }
            //else
            //{
            //    currentChat = chat5_2;
            //    missonController.GetComponent<MissonContorller>().dropLeaf = true;
            //}
        }
        else if (gameObject.transform.GetChild(0).CompareTag("ChatNPC8"))
        {
            if (missonController.GetComponent<MissonContorller>().map5Clear) //== true && missonController.GetComponent<MissonContorller>().clubClear == true )
            {
                currentChat = chat8_2;
            }
            else
            {
                if(missonController.gameObject.GetComponent<MissonContorller>().missonNum == 4)
                {
                    currentChat = chat8_1;
                  
                }
                
            }
        }
        if (SentanceNum >= currentChat.Count)
        {
            
            chatCanvus.SetActive(false);
            GameObject.Find("PanelController").GetComponent<BtnControl>().panelOn = false;
            while(i == 0){
                missonController.GetComponent<MissonContorller>().missonNum++;
                i++;
            }
            
        }
        else
        {
            myTextMeshProUGUI.text = currentChat[SentanceNum];
            i = 0;
        }
    }

    public void ClickNext()
    {
        Debug.Log("Click");
        SentanceNum++;
    }
}
