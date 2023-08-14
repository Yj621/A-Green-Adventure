using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public int bpm = 0;
    double currentTime =0d;
    [SerializeField] Transform tfNoteAppear = null;
    [SerializeField] GameObject goNote =null;
    TimingManager theTimingManager;
    EffectManager theEffectManager;

    void Start()
    {
        theEffectManager = FindObjectOfType<EffectManager>();
        theTimingManager = GetComponent<TimingManager>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= 60d / bpm)
        {
            GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
            currentTime -= 60d/bpm;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Note"))
        { 
            if(other.GetComponent<Note>().GetNoteFlag())
                theEffectManager.JudgementEffect(4);
            theTimingManager.boxNoteList.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
