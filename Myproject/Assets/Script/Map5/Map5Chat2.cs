using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Map5Chat1 : MonoBehaviour
{
    List<string> myList = new List<string>();
    private TextMeshProUGUI myTextMeshProUGUI;
    private int SentanceNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        myTextMeshProUGUI = gameObject.transform.GetChild(2).GetComponent< TextMeshProUGUI > ();
        myList.Add("안녕?");
        myList.Add("우리집에 온걸 환영해.");
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
