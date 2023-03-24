using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatTracker : Singleton<BeatTracker>, IOnBeatEvent
{
    // singleton insurance, private set
    //public static BeatTracker Instance { get; private set; }

    public int BeatValue { get; private set; }

    private void Start()
    {
        // subscribe to onbeat event
        MusicManager.Instance.OnBeat += OnBeatEvent;
        
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
    }
}
