using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MissonUI : MonoBehaviour
{
    List<string> myList = new List<string>();
    private TextMeshProUGUI myTextMeshProUGUI;
    private GameObject missonControl;
    private int missionNum;
    // Start is called before the first frame update
    void Start()
    {
        missionNum = GameObject.Find("MissionController").GetComponent<MissonContorller>().missonNum;
        myTextMeshProUGUI = GetComponent<TextMeshProUGUI>();
        myList.Add("������ Ž������");
        myList.Add("ȣ���� ���� ������ ã��");
        myList.Add("������ �ֹο��� ���� �ɾ��");
        myList.Add("������ ���÷� ã�ư� ����");
        myList.Add("���ð� ������ ������ ã��");
        myList.Add("������ ������ �ֹο��� ���ư���");
        myList.Add("������ ������");
    }

    // Update is called once per frame
    void Update()
    {
        missionNum = GameObject.Find("MissionController").GetComponent<MissonContorller>().missonNum;
        myTextMeshProUGUI.text = myList[missionNum] ;
    }
}
