using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    UnityEngine.UI.Image noteImage;
    public float noteSpeed = 400;
    
    void Start()
    {
        noteImage = GetComponent<UnityEngine.UI.Image>();
    }
    public void HideNote()
    {
        noteImage.enabled = false;
    }
    void Update(){
        transform.localPosition += Vector3.right * noteSpeed * Time.deltaTime;
    }
    public bool GetNoteFlag()
    {
        return noteImage.enabled;
    }
}
