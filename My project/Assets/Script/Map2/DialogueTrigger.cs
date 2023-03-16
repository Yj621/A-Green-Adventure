using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue info;


    public void Trigger()
    {
        var system = FindObjectOfType<DialogueSystem>(); //현재 다이얼로그 시스템을 검색 
        system.Begin(info); //Begin함수 호출

    }
}
