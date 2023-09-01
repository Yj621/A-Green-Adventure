using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();
    int[] judgementRecord;
    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null;
    Vector2[] timingBoxs = null;
    EffectManager theEffect;
    ScoreManager theScoreManager;
    private void Start()
    {
        judgementRecord = new int[5];
        theEffect = FindObjectOfType<EffectManager>();
        theScoreManager = FindObjectOfType<ScoreManager>();
        // 타이밍 박스 설정
        
        timingBoxs = new Vector2[timingRect.Length];
        for(int i = 0; i< timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.x -  timingRect[i].rect.width / 2,
                              Center.localPosition.x + timingRect[i].rect.width / 2);
        }                  
    }
    

    public void CheckTiming()
    {
        for(int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosX = boxNoteList[i].transform.localPosition.x;

            // 판정 순서 : Perfect -> Cool -> Good -> Bad
            for (int j = 0; j < timingBoxs.Length; j++)
            {
                if (timingBoxs[j].x <= t_notePosX && t_notePosX <= timingBoxs[j].y)
                {
                    // 노트 제거
                    boxNoteList[i].GetComponent<Note>().HideNote();
                    boxNoteList.RemoveAt(i);
                    Debug.Log("Hit"+j);

                    // 이펙트 연출 ⭐⭐
                    if (j < timingBoxs.Length - 1)
                    { // Perfect, Cool, Good 판정때만 이펙트 효과. Bad 일땐 X
                        theEffect.NoteHitEffect();
                    }

                    theScoreManager.IncreaseScore(j);//점수 증가
                    theEffect.JudgementEffect(j);//판정 연출
                    judgementRecord[j]++; //판정 기록
                    return;
                }
            }
        }

        theEffect.JudgementEffect(4);
        MissRecord(); //판정 기록
    }
    public int[] GetJudgementRecord()
    {
        return judgementRecord;
    }
    public void MissRecord()
    {
        judgementRecord[4]++;
    }

}