using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Chat : MonoBehaviour
{
    List<string> chat2 = new List<string>() { "�ȳ�?", "���� �� �Ƹ�����?", "������ ������ ������Ⱦ�", "�̴�θ� �����鵵 ��������ž�!", "������ ���� ������ ã���ְھ�?" };
    List<string> chat4 = new List<string>() { "���ÿ� �°� ȯ����", "�� ���ô� �ι�°�� ������� �����ΰ� �˾�?", "���� �� ���� ���� ���ð� ����", "�츮 ���� ��� �ִ� ������", "���� �Ⱥ� �����ٷ�?" };
    List<string> chat5_1 = new List<string>() { "�ȳ�?", "�츮���� �°� ȯ����.", "���� �������ϴٰ�?", "���⼼�� �ʹ� ���� ���ͼ�\n ��� �ǿ��� �Ҿ��°�?" };
    List<string> chat5_2 = new List<string>() { "���� ����������!","�������� ������!","����!\n ���� �����̾�." };
    List<string> chat8_1 = new List<string>() { "�� ����?", "�¾�, ������ ���ÿ� ��� �־�", "�Ⱥ� �����༭ ����", "����� �̷��� �l���ϰ� �����Ǿ�����", "�� ���ô� ���� ��ȭ�������", "�� ��� �����غ��� ����� �ٷ�?" };
    List<string> chat8_2 = new List<string>() { "����, �̰� �� �����̾�" };
    List<string> currentChat = new List<string>();
    private TextMeshProUGUI myTextMeshProUGUI;
    private int SentanceNum = 0;
    private GameObject missonController;
    public GameObject chatCanvus;

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
            else
            {
                currentChat = chat5_2;
                missonController.GetComponent<MissonContorller>().dropLeaf = true;
            }
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
        }
        else
        {
            //��� ������Ʈ? ����?
            myTextMeshProUGUI.text = currentChat[SentanceNum];
        }
    }

    public void ClickNext()
    {
        Debug.Log("Click");
        SentanceNum++;
    }
}
