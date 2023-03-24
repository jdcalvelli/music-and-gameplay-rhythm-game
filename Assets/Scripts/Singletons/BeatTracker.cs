using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatTracker : Singleton<BeatTracker>, IOnBeatEvent, IOnCueEvent
{
    // singleton insurance, private set
    //public static BeatTracker Instance { get; private set; }

    public int BeatValue { get; private set; }
    public int BeatTime { get; private set; }
    public int NextBeatTime { get; private set; }
    
    // calculating tolerance window
    private int _tWindowStart;
    private int _tWindowEnd;
    public int TWindow { get; private set; }

    private void Start()
    {
        // subscribe to onbeat event
        MusicManager.Instance.OnBeat += OnBeatEvent;
        MusicManager.Instance.OnCue += OnCueEvent;
        
        // initialize beatvalue to 0
        BeatValue = 0;
    }

    public void OnBeatEvent(object sender, EventArgs e)
    {
        // track which beat we are on (1 to 4)
        if (BeatValue % 4 == 0)
        {
            BeatValue = 1;
        }
        else
        {
            BeatValue++;
        }
        
        // set beat values
        BeatTime = MusicManager.Instance.NormalizedCurrentPlaybackTime;
        NextBeatTime = BeatTime + MusicManager.Instance.NormalizedBeatDuration;
    }

    public void OnCueEvent(object sender, MusicManager.CueEventArgs e)
    {
        // quick and dirty for now
        // first cue save time into twindowstart

        switch (e.CueName)
        {
            case "TWindowStart":
                _tWindowStart = MusicManager.Instance.NormalizedCurrentPlaybackTime;
                break;
            case "TWindowEnd":
                // second cue save time into twindowend and set twindow
                _tWindowEnd = MusicManager.Instance.NormalizedCurrentPlaybackTime;
                // applied on either side of the beat in question
                TWindow = (_tWindowEnd - _tWindowStart) / 2;
                break;
        }

        //Debug.Log("twindow start " + _tWindowStart);
        //Debug.Log("twindow end " + _tWindowEnd);
        //Debug.Log("twindow " + TWindow);
    }
}
