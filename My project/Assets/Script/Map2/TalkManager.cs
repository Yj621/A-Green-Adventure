using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData; //Ű,��

    void Awake()
    {
        talkData= new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000,new string[] {"�ȳ�?", "���� ��¾���̾�?", "�ܺ����� �� �͵� �������̳�.", "��, ���� ���� �ֹ��̾�", "�� ������ �����̾���..", "���ݵ� ���ƺ��δٰ�?",
        "��������.. ȣ���� �̷��� �ʾҴµ� ���̾�.", "ȣ���� ����ֳİ�?", "�� ������ ������ �־�."});
    }
    public string GetTalk(int id, int talkIndex)
    {
        return talkData[id][talkIndex];
    }
}
