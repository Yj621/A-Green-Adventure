using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterFrame : MonoBehaviour
{
    AudioSource Club;
    bool MusicStart;
    bool MusicFinished; // 새로운 변수 추가
    
    public Result theResult;

    private void Start()
    {
        Club = GetComponent<AudioSource>();
        MusicFinished = false; // 초기화
        theResult = FindObjectOfType<Result>();
    }


    private void Update()
    {
        if (MusicStart && !Club.isPlaying && !MusicFinished)
        {
            MusicFinished = true;
            // 배경음악이 끝났을 때
            Debug.Log("BGM끝");
            theResult.ShowResult();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!MusicStart)
        {
            if (other.CompareTag("Note"))
            {
                Club.Play();
                MusicStart = true;
            }
        }
    }
}
