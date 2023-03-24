using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : Singleton<GameManager>, IOnCueEvent
{

    [SerializeField] private GameObject hotDogPrefab;
    private GameObject _hotDogObj;
    
    // this is going to have to be set dynamially somehow
    public HotDogController CurrentHotDog;

    private void Start()
    {
        MusicManager.Instance.OnCue += OnCueEvent;
    }

    private void Update()
    {
        //Debug.Log(BeatTracker.Instance.BeatValue);
        //Debug.Log("beat duration " + MusicManager.Instance.BeatDuration);
        //Debug.Log("--------");
        //Debug.Log("this beat " + BeatTracker.Instance.BeatTime);
        //Debug.Log("--------");
        //Debug.Log("next beat " + BeatTracker.Instance.NextBeatTime);
    }

    public void OnCueEvent(object sender, MusicManager.CueEventArgs e)
    {
        switch (e.CueName)
        {
            case "InstantiateGlizzy":
                // this is disgusting i have to find a better way
                _hotDogObj = Instantiate(hotDogPrefab);
                CurrentHotDog = _hotDogObj.GetComponent<HotDogController>();
                _hotDogObj.GetComponentInChildren<HotDogView>().transform.SetPositionAndRotation(
                    new Vector3(-12f, -2, 0), 
                    quaternion.identity);
                break;
            case "DeinstantiateLastGlizzy":
                Destroy(_hotDogObj);
                CurrentHotDog = null;
                break;
        }
    }
}
