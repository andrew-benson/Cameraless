using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmChair : ParanormalTrigger {

    public Rigidbody cigarette, lighter, tray;
    private GameObject cable;
    private float force = 1;


    void Awake()
    {
        StartEvent += LookAtChairEvent;

    }

    private void LookAtChairEvent(object sender, EventArgs e)
    {
        Invoke(nameof(AddForceToTable), eventTimeDelay);
    }

    private void AddForceToTable()
    {
        cigarette.AddForce(new Vector3(force, 0.3f, -force), ForceMode.Impulse);
        lighter.AddForce(new Vector3(force, 0.3f, -force), ForceMode.Impulse);
        tray.AddForce(new Vector3(force, 0.3f, -force), ForceMode.Impulse);

        cable = GameObject.Find("RopeRigidbodyContainer");
        cable.transform.GetChild(0).GetComponent<Rigidbody>()?.AddForce(new Vector3(force*20, 0, 0), ForceMode.Acceleration);
        cable.transform.GetChild(0).GetComponent<Rigidbody>()?.AddForce(new Vector3(-force * 20, 0, 0), ForceMode.Impulse);

        SoundManager.PlaySound(soundFX);

        FinishedEvent();
    }

    private void AddForceToLight()
    {
        cable.transform.GetChild(0).GetComponent<Rigidbody>()?.AddForce(new Vector3(force * 10, 0, 0), ForceMode.Acceleration);
        cable.transform.GetChild(0).GetComponent<Rigidbody>()?.AddForce(new Vector3(-force * 10, 0, 0), ForceMode.Impulse);
    }
}
