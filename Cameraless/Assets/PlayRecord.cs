using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRecord : ParanormalTrigger {

    public GameObject jackInTheBox;
    public AudioSource ambientSound;
    public Transform position2, position3;
    public Transform vinylTransform;
    private AudioSource audioSource;
    private float spinSpeed = 20f;

	void Awake () {
        StartEvent += PlayCreepyMusic;
        audioSource = GetComponent<AudioSource>();      
    }

    private void PlayCreepyMusic(object sender, EventArgs e)
    {
        audioSource.Play();

        WakeUpJack();

        Invoke(nameof(Blink), 10f);

        Invoke(nameof(StartAmbientMusic), 22);

        FinishedEvent(20);

        StartEvent -= PlayCreepyMusic;
        StartEvent += MoveJackInBox;
    }

    private void Blink()
    {
        MainLight.mainLightGameObject.GetComponent<MainLight>().Blink();
    }

    private void MoveJackInBox(object sender, EventArgs e)
    {
        JackInTheBox.CurrentStage++;

        audioSource.UnPause();

        if(JackInTheBox.CurrentStage == JackInTheBox.Stage.Stage2)
        {
            jackInTheBox.transform.position = position2.position;
        }

        else if (JackInTheBox.CurrentStage == JackInTheBox.Stage.Stage3)
        {
            jackInTheBox.transform.position = position3.position;
            jackInTheBox.transform.eulerAngles = position3.eulerAngles;
        }

        jackInTheBox.GetComponent<Collider>().enabled = true;
        FinishedEvent(20f);
    }

    private void StartAmbientMusic()
    {
        ambientSound.Play();
    }

    private void Update()
    {
        if (audioSource.isPlaying)
            RotateVinyl();
    }

    private void RotateVinyl()
    {
        vinylTransform.Rotate(Vector3.up * Time.deltaTime * spinSpeed, Space.Self);
    }

    private void WakeUpJack()
    {
        jackInTheBox.SetActive(true);
    }
}
