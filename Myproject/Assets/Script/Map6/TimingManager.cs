using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();
    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null;
    Vector2[] timingBoxs = null;
    EffectManager theEffect;

    private void Start()
    {
        theEffect = FindObjectOfType<EffectManager>();

        // 타이밍 박스 설정
        
        timingBoxs = new Vector2[timingRect.Length];
        for(int i = 0; i< timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.y -  timingRect[i].rect.height / 2,
                Center.localPosition.y + timingRect[i].rect.height / 2);
        }                   
    }

    public void CheckTiming()
    {
        for(int i = 0; i<boxNoteList.Count; i++)
        {
            float t_NotePosY = boxNoteList[i].transform.localPosition.y;

            for(int x =0; x<timingBoxs.Length; x++)
            {
                if(timingBoxs[x].x<= t_NotePosY && t_NotePosY<=timingBoxs[x].y)
                {
                    //노트 제거
                    boxNoteList[i].GetComponent<Note>().HideNote();
                    boxNoteList.RemoveAt(i);

                    //이펙트 연출                    
                    if(x<timingBoxs.Length - 1)
                        theEffect.NoteHitEffect();
                    theEffect.JudgementEffect(x);
                    return;
                }
            }
               
        }
        theEffect.JudgementEffect(timingBoxs.Length);
    }
}