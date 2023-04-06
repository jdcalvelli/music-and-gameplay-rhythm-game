using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : Singleton<GameManager>, IOnBeatEvent
{

    [SerializeField] private GameObject hotDogPrefab;
    public GameObject HotDogObj;
    public GameObject PriorHotDogObj;
    
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
                PriorHotDogObj = HotDogObj;
                // instantiate new dog
                HotDogObj = Instantiate(hotDogPrefab); 
                HotDogObj.GetComponentInChildren<HotDogView>().transform.SetPositionAndRotation(
                    new Vector3(-12f, -2, 0), 
                    quaternion.identity);
                break;
            case 1:
                // this is erroring for the first one bc there is no reference yet
                CurrentHotDog = HotDogObj.GetComponent<HotDogController>();
                // if we are on the first beat, deinstantiate the old one
                Destroy(PriorHotDogObj);
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }
}
