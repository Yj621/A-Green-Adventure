using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Chat : MonoBehaviour
{
    List<string> chat5_1 = new List<string>() { "안녕?", "우리집에 온걸 환영해." };
    List<string> chat5_2 = new List<string>() { "고마워!\n 여기 보답이야." };
    List<string> currentChat = new List<string>();
    private TextMeshProUGUI myTextMeshProUGUI;
    private int SentanceNum = 0;
    private GameObject missonController;
    public GameObject chatCanvus;

    // Start is called before the first frame update

    void Start()
    {
        missonController = GameObject.Find("MissionController");
        myTextMeshProUGUI = chatCanvus.gameObject.transform.GetChild(2).GetComponent< TextMeshProUGUI >();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.GetChild(0).CompareTag("ChatNPC5"))
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
        SentanceNum++;
    }
}
