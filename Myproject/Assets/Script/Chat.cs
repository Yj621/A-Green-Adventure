using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Chat : MonoBehaviour
{
    List<string> chat2 = new List<string>() { "???", "?? ? ?????", "??? ??? ?????", "???? ???? ??????!", "??? ?? ??? ??????" };
    List<string> chat4 = new List<string>() { "??? ?? ???", "? ??? ???? ???? ???? ???", "?? ? ?? ?? ??? ??", "?? ?? ?? ?? ???", "?? ?? ?????" };
    List<string> chat5_1 = new List<string>() { "???", "???? ?? ???.", "?? ???????", "???? ?? ?? ???\n ?? ??? ?????" };
   // List<string> chat5_2 = new List<string>() { "?? ?????!","???? ???!","???!\n ?? ????." };
    List<string> chat8_1 = new List<string>() { "? ???", "??, ??? ??? ?? ??", "?? ???? ???", "??? ??? ???? ??????", "? ??? ?? ??????", "? ?? ????? ??? ???" };
    List<string> chat8_2 = new List<string>() { "???, ?? ? ????" };
    List<string> currentChat = new List<string>();
    private TextMeshProUGUI myTextMeshProUGUI;
    private int SentanceNum = 0;
    private GameObject missonController;
    public GameObject chatCanvus;
    int i = 0;
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
            if (missonController.GetComponent<MissonContorller>().map5Clear == true && missonController.GetComponent<MissonContorller>().clubClear == true )
            {
                currentChat = chat8_2;
            }
            else
            {
                currentChat = chat8_1;;
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
