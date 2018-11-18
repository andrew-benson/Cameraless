using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {
    RaycastHit raycastHitInfo;
    public static EventHandler<LookEventTriggerArgs> LookedAtEvent;
    public static bool IsBusy;
    public float checkEventTimer = 1; // The frequency at which the LookAtEvent is triggered
    private float timer;

    // Keep track of how many events we have triggered
    public static int activityCounter = 0;

	// Use this for initialization
	void Start () {
        timer = checkEventTimer;
	}

    private void FixedUpdate()
    {
        if (timer < 0)
        {
            if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out raycastHitInfo) && !IsBusy)
            {

                if (raycastHitInfo.collider.name == "Record Player" && activityCounter < 0)
                    return;

                LookedAtEvent.Invoke(this, new LookEventTriggerArgs() { RaycastHitInfo = raycastHitInfo });
                Debug.Log("Looked at: " + raycastHitInfo.collider.name);
            }
            timer = checkEventTimer;
        }
    }

    static void BusyStatus(bool status)
    {
        IsBusy = status;
    }

    // Update is called once per frame
    void Update () {

        timer -= Time.deltaTime;
	}
}

public class LookEventTriggerArgs: EventArgs
{
    public RaycastHit RaycastHitInfo;
}
