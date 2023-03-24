using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotDogController : MonoBehaviour, IOnBeatEvent, IOnBarEvent
{

    [SerializeField] private HotDogView hotDogView;
    
    public HotDog _hotDog = new HotDog();
    
    void Start()
    {
        // subscribe to events
        MusicManager.Instance.OnBeat += OnBeatEvent;
        MusicManager.Instance.OnBar += OnBarEvent;
    }

    public void OnBeatEvent(object sender, EventArgs e)
    {
        // call view code to move the glizzy
        hotDogView.MoveGlizzy(BeatTracker.Instance.BeatValue);
    }

    public void OnBarEvent(object sender, EventArgs e)
    {
        // just print out the hot dog condiment status
        //foreach (var condiment in _hotDog.CondimentList)
        //{
        //    Debug.Log(condiment);
        //}
    }
}
