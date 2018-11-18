using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParanormalTrigger : MonoBehaviour {

    public EventHandler StartEvent;
    public AudioClip soundFX;
    public float eventTimeDelay => UnityEngine.Random.Range(3, 6);
    public float timeTilNextEvent => UnityEngine.Random.Range(10, 13);

    // Use this for initialization
    void Start ()
    {
        EventManager.LookedAtEvent += LookedAtObject;
	}

    public virtual void LookedAtObject(object sender, LookEventTriggerArgs e)
    {
        if (e.RaycastHitInfo.collider.name == this.GetComponent<Collider>().name)
        {
            EventManager.activityCounter++;
            EventManager.IsBusy = true;
            GetComponent<Collider>().enabled = false;

            StartEvent.Invoke(this, EventArgs.Empty);
        }
    }

    protected void FinishedEvent()
    {
        Invoke(nameof(SetEventManagerNotBusy),timeTilNextEvent);
    }

    protected void FinishedEvent(float time)
    {
        Invoke(nameof(SetEventManagerNotBusy), time);
    }

    void SetEventManagerNotBusy()
    {
        EventManager.IsBusy = false;
    }
}
