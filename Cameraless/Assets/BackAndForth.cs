using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.Tween;
public class BackAndForth : MonoBehaviour
{

    public float delta = 5.5f;  // Amount to move left and right from the start point
    public float speed = 0.0f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    public void Play()
    {
        GetComponent<AudioSource>().Play();

        gameObject.Tween("IncreaseSpeed", speed, 1f, 1f, TweenScaleFunctions.CubicEaseIn, (t) => {
            speed = t.CurrentValue;
            GetComponent<AudioSource>().volume = t.CurrentValue;
        });
    }

    public void Stop()
    {
        gameObject.Tween("DecreaseSpeed", speed, 0, 0.6f, TweenScaleFunctions.CubicEaseIn, (t) => {
            speed = t.CurrentValue;
            GetComponent<AudioSource>().volume = t.CurrentValue;
        });

        GetComponent<AudioSource>().Stop();
    }

    void Update()
    {
        Vector3 v = startPos;
        v.x += delta * Mathf.Sin(Time.time * speed);

        transform.position = v;
    }
}
