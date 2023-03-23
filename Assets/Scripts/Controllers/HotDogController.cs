using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotDogController : MonoBehaviour, IOnBeatEvent
{

    [SerializeField] private HotDogView hotDogView;
    
    private HotDog _hotDog = new HotDog();
    
    void Start()
    {
        // subscribe to events
        MusicManager.Instance.OnBeat += OnBeatEvent;
    }

    public void OnBeatEvent(object sender, EventArgs e)
    {
        // call view code to move the glizzy
        hotDogView.MoveGlizzy(BeatTracker.Instance.GetBeatValue());
    }
}
