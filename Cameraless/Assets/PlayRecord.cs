using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRecord : ParanormalTrigger {

    public AudioSource audioSource;

	void Awake () {
        StartEvent += PlayCreepyMusic;
	}

    private void PlayCreepyMusic(object sender, EventArgs e)
    {
        audioSource.Play();
        Invoke("FinishedEvent", 3);
    }
}
