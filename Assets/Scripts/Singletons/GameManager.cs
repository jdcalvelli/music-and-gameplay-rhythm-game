using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : Singleton<GameManager>, IOnBeatEvent
{

    [SerializeField] private GameObject hotDogPrefab;
    private GameObject _hotDogObj;
    private GameObject _priorHotDogObj;
    
    public HotDogController CurrentHotDog;

    private void Start()
    {
        MusicManager.Instance.OnBeat += OnBeatEvent;
    }

    // first in last out cue based on on beat
    public void OnBeatEvent(object sender, EventArgs e)
    {
        switch (BeatTracker.Instance.BeatValue)
        {
            case 4:
                // first set the old one to the old one spot
                _priorHotDogObj = _hotDogObj;
                // instantiate new dog
                _hotDogObj = _hotDogObj = Instantiate(hotDogPrefab); 
                _hotDogObj.GetComponentInChildren<HotDogView>().transform.SetPositionAndRotation(
                    new Vector3(-12f, -2, 0), 
                    quaternion.identity);
                break;
            case 1:
                // this is erroring for the first one bc there is no reference yet
                CurrentHotDog = _hotDogObj.GetComponent<HotDogController>();
                // if we are on the first beat, deinstantiate the old one
                Destroy(_priorHotDogObj);
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }
}
