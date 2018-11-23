using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLight : MonoBehaviour {

    public static Light mainLightGameObject;
    //public GameObject ghost;
    public GameObject jackInTheBox;

    public static void TurnOff()
    {
        mainLightGameObject.enabled = false;
    }

	// Use this for initialization
	void Awake () {
        mainLightGameObject = GetComponent<Light>();
    }

    private void Start()
    {
        //StartCoroutine(BlinkingLightRoutine());
    }

    public void Blink()
    {
        StartCoroutine(BlinkingLightRoutine(2));
    }

    /// <summary>
    /// Use and even numbers of blinks if you want the light to with the same boolean value as it started with
    /// </summary>
    IEnumerator BlinkingLightRoutine(int numberOfBlinks, float shortestPause = 0.05f, float longestPause = 0.3f)
    {

        for (int i = 0; i < numberOfBlinks * 2; i++)
        {
            mainLightGameObject.enabled = mainLightGameObject.enabled ? false:true;
            yield return new WaitForSeconds(UnityEngine.Random.Range(shortestPause,longestPause));
        }

        // FinishedEvent
    }
}
