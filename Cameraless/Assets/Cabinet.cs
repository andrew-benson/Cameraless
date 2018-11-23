using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : ParanormalTrigger {

	void Awake () {
        StartEvent += LookedAtCabinet;
	}

    private void LookedAtCabinet(object sender, EventArgs e)
    {
        Invoke(nameof(PlayCloseDoorsAnimation), 2);
        Invoke(nameof(PlaySoundEffect), 5);
    }

    public override void LookedAtObject(object sender, LookEventTriggerArgs e)
    {
        base.LookedAtObject(sender, e);
    }

    private void PlaySoundEffect()
    {
        GetComponent<AudioSource>().PlayOneShot(soundFX);
    }

    private void PlayCloseDoorsAnimation()
    {
        GetComponent<Animator>().Play("cabinet_door1");
        FinishedEvent(5);
    }
}
