using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Map5Chat2 : MonoBehaviour
{
    List<string> myList = new List<string>();
    public TextMeshProUGUI myTextMeshProUGUI;
    private int SentanceNum = 0;

    // Start is called before the first frame update
    void Start()
    {

        myList.Add("����!\n ���� �����̾�.");
   
    }

    // Update is called once per frame
    void Update()
    {
        if(SentanceNum >= myList.Count)
        {
            gameObject.SetActive(false);
            GameObject.Find("PanelController").GetComponent<BtnControl>().panelOn = false;
        }
        else
        {
            myTextMeshProUGUI.text = myList[SentanceNum];
        }
    }

    public void ClicNext()
    {
        SentanceNum++;
    }
}
