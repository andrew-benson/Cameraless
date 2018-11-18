using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmChair : ParanormalTrigger {
    public Rigidbody cigarette, lighter, tray;
    private float force = 1;
	// Use this for initialization
	void Awake () {
        StartEvent += LookAtChairEvent;
	}

    private void LookAtChairEvent(object sender, EventArgs e)
    {
        cigarette.AddForce(new Vector3(force, 0.3f, -force), ForceMode.Impulse);
        lighter.AddForce(new Vector3(force, 0.3f, -force), ForceMode.Impulse);
        tray.AddForce(new Vector3(force, 0.3f, -force), ForceMode.Impulse);

        Invoke("FinishedEvent", 10);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
