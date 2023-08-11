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
        myList.Add("숲속을 탐험하자");
        myList.Add("호수가 막힌 원인을 찾자");
        myList.Add("도시의 주민에게 말을 걸어보자");
        myList.Add("오염된 도시로 찾아가 보자");
        myList.Add("도시 주민의 형을 찾아보자");
        myList.Add("도시를 돌아다니며 오염된 원인을 찾자");
        myList.Add(" 집을 정리하고 낭비되는 전기를 막자");
        myList.Add("오염된 도시의 주민에게 돌아가자");
        myList.Add("빌딩을 들어가보자");
        myList.Add("사장과 얘기해 보자");
        myList.Add("사장을 쓰러뜨리자");
        myList.Add("끝");
    }

    // Update is called once per frame
    void Update()
    {
        missionNum = GameObject.Find("MissionController").GetComponent<MissonContorller>().missonNum;
        myTextMeshProUGUI.text = myList[missionNum] ;
    }
}
