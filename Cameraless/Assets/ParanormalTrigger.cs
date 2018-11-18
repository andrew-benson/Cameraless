using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParanormalTrigger : MonoBehaviour {

    public EventHandler StartEvent;

    // Use this for initialization
    void Start () {
        EventManager.LookedAtEvent += LookedAtObject;
	}

    public virtual void LookedAtObject(object sender, LookEventTriggerArgs e)
    {
        if (e.RaycastHitInfo.collider.name == this.GetComponent<Collider>().name)
        {
            EventManager.IsBusy = true;
            GetComponent<Collider>().enabled = false;

            StartEvent.Invoke(this, EventArgs.Empty);
        }
    }

    protected void FinishedEvent()
    {
        EventManager.IsBusy = false;
    }
}
