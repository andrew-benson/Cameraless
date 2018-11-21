using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.Tween;

public class EntranceDoor : ParanormalTrigger {

    public Transform startMarker;
    public Transform endMarker;
    public GameObject ghost;
    public float seconds = 1;

    // Use this for initialization
    void Awake () {
        StartEvent += delegate { Invoke(nameof(LookedAtDoor), 0.5f);  } ;
    }

    private void LookedAtDoor()
    {
        SoundManager.PlaySound(soundFX);

        ghost.Tween("MoveGhost", startMarker.position, endMarker.position, seconds, TweenScaleFunctions.Linear, (t) =>
        {
            // progress
            ghost.transform.position = t.CurrentValue;
        }, (t) => {
            FinishedEvent(13f);
        });
    }
}
