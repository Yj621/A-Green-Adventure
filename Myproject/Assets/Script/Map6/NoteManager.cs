using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    private int bpm = 120;
    float currentTime =0f;
    [SerializeField] Transform tfNoteAppear = null;
    [SerializeField] GameObject goNote =null;
    TimingManager theTimingManager;
    EffectManager theEffect;

    void Start()
    {
        theEffect = FindObjectOfType<EffectManager>();
        theTimingManager = GetComponent<TimingManager>();
        // BPM을 기반으로 노트 생성 주기 계산
        float noteSpawnInterval = 60f / bpm;
        // 노트 생성 주기를 적용
        InvokeRepeating("SpawnNote", noteSpawnInterval, noteSpawnInterval);
    }
    // 노트 생성 메서드
    void SpawnNote()
    {
        GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);
        t_note.transform.SetParent(this.transform);
        theTimingManager.boxNoteList.Add(t_note);
    }


    void Update()
    {

        // currentTime += Time.deltaTime;

        // if(currentTime >= 60d / bpm)
        // {
        //     GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);
        //     t_note.transform.SetParent(this.transform);
        //     theTimingManager.boxNoteList.Add(t_note);
        //     currentTime -= 60d/bpm;
        // }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            if (collision.GetComponent<Note>().GetNoteFlag())
            {
                theTimingManager.MissRecord();
                theEffect.JudgementEffect(4);
            }
            theTimingManager.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
