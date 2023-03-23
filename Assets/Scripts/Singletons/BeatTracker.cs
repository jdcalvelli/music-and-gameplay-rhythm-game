using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatTracker : Singleton<BeatTracker>, IOnBeatEvent
{
    // singleton insurance, private set
    //public static BeatTracker Instance { get; private set; }

    private int _beatValue;

    private void Start()
    {
        // subscribe to onbeat event
        MusicManager.Instance.OnBeat += OnBeatEvent;
        
        // initialize beatvalue to 0
        _beatValue = 0;
    }

    public void OnBeatEvent(object sender, EventArgs e)
    {
        // track which beat we are on (1 to 4)
        if (_beatValue % 4 == 0)
        {
            _beatValue = 1;
        }
        else
        {
            _beatValue++;
        }
    }

    // getter
    public int GetBeatValue()
    {
        return _beatValue;
    }
}
