using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.Tween;
public class JumpScare : MonoBehaviour {

    public float timeToComplete;
    public AudioClip scream;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void JumpUp()
    {
        foreach (var renderer in GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = true;
        }

        gameObject.Tween("JumpScare", transform.localPosition.y, -1.99f, timeToComplete, TweenScaleFunctions.Linear, (t) => {
            transform.localPosition = new Vector3(transform.localPosition.x, t.CurrentValue, transform.localPosition.z);
        }, (t) => {
            SoundManager.PlayOneShotSound(scream);
            Invoke(nameof(Outro), 3);
        });
    }

    public void Outro()
    {
        var go = GameObject.Find("Panel");
        go.GetComponent<FadeOut>().OutroFade();
    }
}
