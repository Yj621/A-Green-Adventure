using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject Audio;
    public AudioClip soundEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if()
          {
            Audio.GetComponent<AudioSource>().PlayOneShot(soundEffect);
          }
    }
}
