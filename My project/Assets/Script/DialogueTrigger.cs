using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue info;
    public GameObject StartBtn;
    private GameObject panelControl;

    private void Start()
    {
        panelControl = GameObject.Find("PanelController");
    }
    internal static void onClick(Action disappear)
    {
        throw new NotImplementedException();
    }

    public void Trigger()
    {
        var system = FindObjectOfType<DialogueSystem>(); //현재 다이얼로그 시스템을 검색 
        system.Begin(info); //Begin함수 호출
        StartBtn.SetActive(false);
        panelControl.GetComponent<BtnControl>().panelOn = true;
    }
}