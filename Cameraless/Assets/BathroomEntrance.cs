using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomEntrance : ParanormalTrigger {

    Light blinkingLight;

    private void Awake()
    {
        blinkingLight = transform.GetComponentInChildren<Light>();
        StartEvent += LookedAtDoor;
    }

    private void LookedAtDoor(object sender, EventArgs e)
    {
        Invoke(nameof(StartBlinkingLights), eventTimeDelay);
    
        Debug.Log("StartedBlinking");
    }

    IEnumerator BlinkingLightRoutine()
    {
        SoundManager.PlaySound(soundFX);

        float shortPause = 0.1f;
        float longPause = 0.4f;

        blinkingLight.enabled = false;
        yield return new WaitForSeconds(shortPause);
        blinkingLight.enabled = true;
        yield return new WaitForSeconds(longPause);
        blinkingLight.enabled = false;
        yield return new WaitForSeconds(shortPause);
        blinkingLight.enabled = true;
        yield return new WaitForSeconds(shortPause);
        blinkingLight.enabled = false;
        yield return new WaitForSeconds(shortPause);
        blinkingLight.enabled = true;
        yield return new WaitForSeconds(longPause);
        blinkingLight.enabled = false;
        yield return new WaitForSeconds(shortPause);
        blinkingLight.enabled = true;
        yield return new WaitForSeconds(longPause);
        blinkingLight.enabled = false;

        FinishedEvent();
    }

    private void StartBlinkingLights()
    {
        StartCoroutine(nameof(BlinkingLightRoutine));
    }
}
