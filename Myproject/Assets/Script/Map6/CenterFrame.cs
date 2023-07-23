using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterFrame : MonoBehaviour
{
    AudioSource Club;
    bool MusicStart;

    private void Start()
    {
        Club = GetComponent<AudioSource>();

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(!MusicStart)
        {
            if(other.CompareTag("Note"))
            {
                Club.Play();
                MusicStart = true;
            }
        }

    }
}
