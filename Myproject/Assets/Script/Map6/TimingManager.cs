using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();
    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null;
    Vector2[] timingBoxs = null;

    void Start()
    {
        //타이밍 박스 설정
        timingBoxs = new Vector2[timingRect.Length];

        for(int i = 0; i<timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.y - timingRect[i].rect.width/2,
                            Center.localPosition.y +  timingRect[i].rect.width/2);
        }
    }

    public void CheckTiming()
    {
        for(int i = 0; i<boxNoteList.Count; i++)
        {
            float t_notePosY = boxNoteList[i].transform.localPosition.x;

            for(int x = 0; x<timingBoxs.Length; x++)
            {
                if(timingBoxs[x].x <=t_notePosY && t_notePosY <= timingBoxs[x].y)
                {
                    Debug.Log("Hit" + x);
                    return;
                }
            }
        }
        Debug.Log("Miss");
    }

    void Update()
    {
        
    }
}
