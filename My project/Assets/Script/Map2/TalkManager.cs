using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitDate;
    public Sprite[] portraitSprite;
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitDate = new Dictionary<int, Sprite>();
        MakeData();

    }

    void MakeData()
    {
        talkData.Add(1000,new string[] {"안녕?", "여긴 어쩐일이야?", "외부인이 온 것도 오랜만이네.", "아, 나는 여기 주민이야", "참 깨끗한 마을이었지..", "지금도 좋아보인다고?",
        "예전에는.. 호수가 이러지 않았는데 말이야.", "호수가 어디있냐고?", "문 밖으로 나가면 있어."});
    }
    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
    public Sprite GetSprite(int id)
    {
        return portraitDate[id];
    }
}

