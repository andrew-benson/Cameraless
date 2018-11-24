using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    static AudioSource audioSource;
    static float defaultVolume = 0;

    public static void PlayOneShotSound(AudioClip clip)
    {
        audioSource.volume = defaultVolume;
        audioSource.PlayOneShot(clip);
    }

    public static void Stop ()
    {
        audioSource.Stop();
    }

    public static void PlaySound(AudioClip clip, float volume = 1)
    {
        audioSource.volume = volume;
        audioSource.PlayOneShot(clip);
    }

    // Use this for initialization
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        defaultVolume = audioSource.volume;
    }

    private void Update()
    {
        
    }
}
