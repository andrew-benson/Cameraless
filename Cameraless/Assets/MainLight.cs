using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLight : MonoBehaviour {

    public static Light mainLightGameObject;
    public GameObject ghost;
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
        StartCoroutine(BlinkingLightRoutine());
    }

    IEnumerator BlinkingLightRoutine()
    {
        float shortPause = 0.1f;
        int turnStage = 20;
        int turnBackStage = 25;


        for (int i = 0; i < 30; i++)
        {
            mainLightGameObject.enabled = mainLightGameObject.enabled ? false:true;
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.05f,0.3f));

            if(i == turnStage || i == turnStage + 1 && mainLightGameObject.enabled == false)
            {
                jackInTheBox.SetActive(false);
                ghost.SetActive(true);
            }
            if (i == turnBackStage || i == turnBackStage + 1 && mainLightGameObject.enabled == false)
            {
                jackInTheBox.SetActive(true);
                ghost.SetActive(false);
            }
        }

        yield return new WaitForSeconds(shortPause);
        mainLightGameObject.enabled = false;
        ghost.SetActive(false);
        jackInTheBox.SetActive(false);

        yield return new WaitForSeconds(3f);
        mainLightGameObject.enabled = true;


        // FinishedEvent
    }
}
