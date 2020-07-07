using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUpdater : MonoBehaviour
{
    public Player playerA, playerB;

    public Slider timerBar;

    public Text timerTxt;

    void Start() {
        timerBar.value = 0f;
        timerTxt.text = "?";
    }

    void Update() {
        var timer = 10 - ((playerA.CanPlay ? playerA.timeAlive : playerB.timeAlive) % 11);
        timerBar.value = timer/10.0f;
        timerTxt.text = timer.ToString();
    }
}
