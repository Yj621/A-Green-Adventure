using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource[] sfxPlayer; //효과음을 담을 배열
    public AudioClip[] sfxClip; //다양한 효과음을 저장할 배열
    public enum Sfx{Die, Walk, Jump, Blind, Button};
    public int sfxPointer; //효과음을 가르키는 커서

    public void SfxPlay(Sfx type)
    {
        switch (type)
        {
            case Sfx.Die:
                sfxPlayer[sfxPointer].clip = sfxClip[0];
                break;
            case Sfx.Walk:
                sfxPlayer[sfxPointer].clip = sfxClip[1];
                break;
            case Sfx.Jump:
                sfxPlayer[sfxPointer].clip = sfxClip[2];
                break;
            case Sfx.Blind:
                sfxPlayer[sfxPointer].clip = sfxClip[3];
                break;    
            case Sfx.Button:
                sfxPlayer[sfxPointer].clip = sfxClip[4];
                break;    
        }
        sfxPlayer[sfxPointer].Play();
        sfxPointer = (sfxPointer + 1) % sfxPlayer.Length;
    }
    // public void StopSfx(Sfx type)
    // {
    //     if (type == Sfx.Walk)
    //     {
    //         foreach (var sfx in sfxPlayer)
    //         {
    //             if (sfx.type == Sfx.Walk)
    //             {
    //                 sfx.Stop();
    //             }
    //         }
    //     }
    // }


}
