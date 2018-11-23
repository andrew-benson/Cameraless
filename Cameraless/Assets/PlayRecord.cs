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
        GetComponentInChildren<Animator>().Play("vinyl_player");

        audioSource.Play();

        WakeUpJack();

        Invoke(nameof(Blink), 10f);

        Invoke(nameof(StartAmbientMusic), 22);

        FinishedEvent(20);

        StartEvent -= PlayCreepyMusic;
    }

    private void Blink()
    {
        MainLight.mainLightGameObject.GetComponent<MainLight>().Blink();
    }

    private void StartAmbientMusic()
    {
        ambientSound.Play();
        TurnOnTriggers();
    }

    private void TurnOnTriggers()
    {
        GameObject.Find("Trigger Manager").GetComponent<TriggerManager>().TurnOnTriggerObjects();
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
