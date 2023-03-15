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
        talkData.Add(1000,new string[] {"�ȳ�?", "���� ��¾���̾�?", "�ܺ����� �� �͵� �������̳�.", "��, ���� ���� �ֹ��̾�", "�� ������ �����̾���..", "���ݵ� ���ƺ��δٰ�?",
        "��������.. ȣ���� �̷��� �ʾҴµ� ���̾�.", "ȣ���� ����ֳİ�?", "�� ������ ������ �־�."});
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

