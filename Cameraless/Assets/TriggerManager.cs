using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class TriggerManager : MonoBehaviour {

    public GameObject[] triggerObjects;
    public bool testmode = true;

    // Use this for initialization
    void Start ()
    {
        if(!testmode)
            TurnOffTriggerObjects();
    }

    private void TurnOffTriggerObjects()
    {
        for (int i = 0; i < triggerObjects.Count(); i++)
        {
            if (i == 0)
                continue;

            triggerObjects[i].GetComponent<Collider>().enabled = false;
        }
    }

    public void TurnOnTriggerObjects()
    {
        for (int i = 0; i < triggerObjects.Count(); i++)
        {
            if (i == 0)
                continue;

            triggerObjects[i].GetComponent<Collider>().enabled = true;
        }
    }
}
