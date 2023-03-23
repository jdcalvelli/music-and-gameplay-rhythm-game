using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour, IOnBeatEvent, IOnBarEvent, IOnCueEvent
{

    [SerializeField] private TestView testView;
    
    void Start()
    {
        // subscribe to events
        MusicManager.Instance.OnBeat += OnBeatEvent;
        MusicManager.Instance.OnBar += OnBarEvent;
        MusicManager.Instance.OnCue += OnCueEvent;
    }
    

    public void OnBeatEvent(object sender, EventArgs e)
    {
        //Debug.Log("on beat");
        testView.PunchOnBeat();
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
}
