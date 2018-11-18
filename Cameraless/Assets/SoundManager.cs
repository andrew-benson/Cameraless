using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    static AudioSource audioSource;

    public static void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    // Use this for initialization
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
