using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.Tween;

public class JackInTheBox : ParanormalTrigger {

    public GameObject footSteps;
    public enum Stage { Stage1 = 0, Stage2, Stage3 };
    public Stage CurrentStage = Stage.Stage1;
    private GameObject recordPlayer;
    public Transform[] positons;

    private void Awake()
    {
        StartEvent += LookedAtJack;
        transform.position = positons[(int)CurrentStage].position;

        //GetComponent<Renderer>().enabled = false;
    }

    private void LookedAtJack(object sender, EventArgs e)
    {
        if (CurrentStage == Stage.Stage1)
        {
            // In stage 3 we show the girl swayin from the ceiling
            // with blood dripping down
            StartCoroutine(BlinkingLightRoutine1());
        }

        if(CurrentStage == Stage.Stage2)
        {
            StartCoroutine(BlinkingLightRoutine2());
        }
        else
        {
            StartCoroutine(BlinkingLightRoutine3());

        }
    }

    private void TurnOnPersonWalking()
    {
        footSteps.GetComponent<BackAndForth>().Play();
    }

    private void TurnOffPersonWalking()
    {
        footSteps.GetComponent<BackAndForth>().Stop();
    }

    IEnumerator BlinkingLightRoutine1()
    {

        for (int i = 0; i < 20; i++)
        {
            MainLight.mainLightGameObject.enabled = MainLight.mainLightGameObject.enabled ? false : true;
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.05f, 0.3f));
        }

        MainLight.mainLightGameObject.enabled = false;
        yield return new WaitForSeconds(3f);

        CurrentStage++;
        transform.position = positons[(int)CurrentStage].position; 
        MainLight.mainLightGameObject.enabled = true;

        FinishedEvent();
        yield return new WaitForSeconds(timeTilNextEvent);
        GetComponent<Collider>().enabled = true;


    }

    IEnumerator BlinkingLightRoutine2()
    {
        CurrentStage++;


        MainLight.mainLightGameObject.enabled = false;
        yield return new WaitForSeconds(2f);

        TurnOnPersonWalking();

        yield return new WaitForSeconds(4);

        TurnOffPersonWalking();
        transform.position = positons[(int)CurrentStage].position;
        MainLight.mainLightGameObject.enabled = true;

        FinishedEvent();

        // Turn the jack in the box back on
        yield return new WaitForSeconds(timeTilNextEvent);
        GetComponent<Collider>().enabled = true;
    }


    IEnumerator BlinkingLightRoutine3()
    {

        MainLight.mainLightGameObject.enabled = false;
        yield return new WaitForSeconds(2f);

        TurnOnPersonWalking();

        yield return new WaitForSeconds(4);

        TurnOffPersonWalking();
        transform.position = positons[(int)CurrentStage].position;
        MainLight.mainLightGameObject.enabled = true;

        FinishedEvent();

        // Turn the jack in the box back on
        yield return new WaitForSeconds(timeTilNextEvent);
        GetComponent<Collider>().enabled = true;
    }

    //private void MoveJackInBox(object sender, EventArgs e)
    //{
    //    if (JackInTheBox.CurrentStage == JackInTheBox.Stage.Stage2)
    //    {
    //        jackInTheBox.transform.position = position2.position;
    //    }

    //    else if (JackInTheBox.CurrentStage == JackInTheBox.Stage.Stage3)
    //    {
    //        jackInTheBox.transform.position = position3.position;
    //        jackInTheBox.transform.eulerAngles = position3.eulerAngles;
    //    }

    //    jackInTheBox.GetComponent<Collider>().enabled = true;
    //    FinishedEvent(20f);
    //}
}
