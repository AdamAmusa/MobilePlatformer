using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] public AudioSource SFX;

    [Header("Audio Clips")]
    public AudioClip collect;
    public AudioClip jump;


    public void PlayCollect()
    {
        SFX.PlayOneShot(collect);
    }

    public void PlayJump()
    {
        SFX.PlayOneShot(jump);
    }

}
