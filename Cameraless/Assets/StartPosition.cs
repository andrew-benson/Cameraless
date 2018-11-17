using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour {

    public Transform startPositon;

	// Use this for initialization
	void Awake () {
        transform.position = startPositon.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
