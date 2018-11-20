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
        Invoke("PlayCloseDoorsAnimation", UnityEngine.Random.Range(2, 4));
    }

    public override void LookedAtObject(object sender, LookEventTriggerArgs e)
    {
        base.LookedAtObject(sender, e);
    }

    private void PlayCloseDoorsAnimation()
    {
        GetComponent<Animator>().Play("cabinet_door1");
        FinishedEvent(5);
    }
}
