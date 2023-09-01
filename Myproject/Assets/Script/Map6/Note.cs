using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    UnityEngine.UI.Image noteImage;
    public float noteSpeed = 400;
    private bool isMoving = true; // 노트 이동 여부를 나타내는 변수
    private CenterFrame centerFrame;
    
    void Start()
    {
        noteImage = GetComponent<UnityEngine.UI.Image>();
        centerFrame = FindObjectOfType<CenterFrame>();
    }
    public void HideNote()
    {
        noteImage.enabled = false;
    }
    void Update()
    {
        if (isMoving)
        {
            // 노트 이동 코드
            transform.localPosition += Vector3.right * noteSpeed * Time.deltaTime;

            // 특정 조건을 만족하면 노트 이동을 멈춘다.
            if (centerFrame != null && centerFrame.MusicFinished) 
            {
                isMoving = false;
            }
        }
    }
    public bool GetNoteFlag()
    {
        return noteImage.enabled;
    }
}
