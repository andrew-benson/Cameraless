using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {
    RaycastHit raycastHitInfo;
    public static EventHandler<LookEventTriggerArgs> LookedAtEvent;
    public static bool IsBusy;
    public float timerDelayCountDown = 1;

    public int EventsTilFinalEvent;
    private static int eventsTilFinalEvent;

    private float timer;
    private float lookFrequency = 1f; // The frequency at which the LookAtEvent is triggered

    // Keep track of how many events we have triggered
    private static int _activityCounter = 0;
    public static int ActivityCounter
    {
        get { return _activityCounter; }
        set 
        {
            if (_activityCounter == eventsTilFinalEvent)
            {
                // Enable final trigger here
                GameObject.Find("Record Player").GetComponent<Collider>().enabled = true;
            }
            _activityCounter = value;
        }
    }


    // Use this for initialization
    void Start () {
        /*
         * 
         * 
         */
        if(EventsTilFinalEvent == 0) GameObject.Find("Record Player").GetComponent<Collider>().enabled = true;

        eventsTilFinalEvent = EventsTilFinalEvent; 
        timer = timerDelayCountDown;
	}

    private void FixedUpdate()
    {
        if (timer < 0)
        {
            if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out raycastHitInfo) && !IsBusy)
            {
                LookedAtEvent.Invoke(this, new LookEventTriggerArgs() { RaycastHitInfo = raycastHitInfo });
                Debug.Log("Looked at: " + raycastHitInfo.collider.name);
            }
            timer = lookFrequency;
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
