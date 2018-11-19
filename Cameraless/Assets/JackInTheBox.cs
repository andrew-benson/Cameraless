using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.Tween;

public class JackInTheBox : ParanormalTrigger {

    static Transform jackTransform;
    public enum Stage { Stage1 = 1, Stage2, Stage3 };
    public static Stage CurrentStage = Stage.Stage1;
    private GameObject recordPlayer;

    public static void Move(Vector3 jackInTheBoxPos)
    {
        jackTransform.position = jackInTheBoxPos;
    }

    private void Awake()
    {
        StartEvent += LookedAtJack;

        jackTransform = GetComponent<Transform>();
        this.gameObject.SetActive(false);
    }

    private void LookedAtJack(object sender, EventArgs e)
    {
        recordPlayer = GameObject.Find("Record Player");

        if (CurrentStage != Stage.Stage3)
        {
            TurnOffMusic();
            FinishedEvent(3f);
        }
        else
        {
            // Play rumble

            // Lights flicker and show child
            MainLight.TurnOff();
            MainLight.mainLightGameObject.GetComponent<MainLight>().Blink();
        }

    }

    private void TurnOffMusic()
    {
        gameObject.Tween("Volume", 1, 0, .3f, TweenScaleFunctions.Linear, (t) =>
        {
            recordPlayer.GetComponent<AudioSource>().volume = t.CurrentValue;
        }, (t) =>
        {
            recordPlayer.GetComponent<Collider>().enabled = true;
            recordPlayer.GetComponent<AudioSource>().Pause();
            recordPlayer.GetComponent<AudioSource>().volume = 1;

            SoundManager.PlaySound(soundFX);
        }); ;
    }

    //IEnumerator BlinkingLightRoutine()
    //{
    //    SoundManager.PlaySound(soundFX);

    //    float shortPause = 0.1f;
    //    float longPause = 0.4f;

    //    blinkingLight.enabled = false;
    //    yield return new WaitForSeconds(shortPause);
    //    blinkingLight.enabled = true;
    //    yield return new WaitForSeconds(longPause);
    //    blinkingLight.enabled = false;
    //    yield return new WaitForSeconds(shortPause);
    //    blinkingLight.enabled = true;
    //    yield return new WaitForSeconds(shortPause);
    //    blinkingLight.enabled = false;
    //    yield return new WaitForSeconds(shortPause);
    //    blinkingLight.enabled = true;
    //    yield return new WaitForSeconds(longPause);
    //    blinkingLight.enabled = false;
    //    yield return new WaitForSeconds(shortPause);
    //    blinkingLight.enabled = true;
    //    yield return new WaitForSeconds(longPause);
    //    blinkingLight.enabled = false;

    //    FinishedEvent();
    //}

}
