using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DigitalRuby.Tween;
public class FadeOut : MonoBehaviour {

    public Text credits;

    public void OutroFade()
    {
        gameObject.Tween("Fadout", GetComponent<Image>().color, new Color(0, 0, 0, 1), 3, TweenScaleFunctions.Linear, (c) =>
        {
            GetComponent<Image>().color = c.CurrentValue;
        }, (c) => {
            Invoke(nameof(FadeInText), 3);
        });
    }

    void FadeInText()
    {
        gameObject.Tween("FadeinText", GetComponent<Image>().color, new Color(1, 1, 1, 1), 3, TweenScaleFunctions.Linear, (c) =>
        {
            credits.color = c.CurrentValue;
        });
    }
}
