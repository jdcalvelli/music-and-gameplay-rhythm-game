using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour, IOnBeatEvent, IOnBarEvent, IOnCueEvent, IOnKey_QEvent
{

    [SerializeField] private TestView testView;
    
    void Start()
    {
        // subscribe to events
        MusicManager.Instance.OnBeat += OnBeatEvent;
        MusicManager.Instance.OnBar += OnBarEvent;
        MusicManager.Instance.OnCue += OnCueEvent;
        
        // subscribe to input events
        InputManager.Instance.OnKey_Q += OnKey_QEvent;
    }
    

    public void OnBeatEvent(object sender, EventArgs e)
    {
        //Debug.Log("on beat");
        testView.PunchOnBeat();
        testView.SquashOnSpecificBeat(BeatTracker.Instance.BeatValue);
    }

    public void OnBarEvent(object sender, EventArgs e)
    {
        //Debug.Log("on bar");
        testView.RotateOnBar();
    }

    public void OnCueEvent(object sender, EventArgs e)
    {
        //Debug.Log("on cue");
        testView.ColorChangeOnCue();
    }

    public void OnKey_QEvent(object sender, EventArgs e)
    {
        Debug.Log("q button pressed");
    }
}
