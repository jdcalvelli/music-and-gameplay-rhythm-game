using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    // this is going to have to be set dynamially somehow
    public HotDogController CurrentHotDog;

    private void Update()
    {
        Debug.Log(BeatTracker.Instance.GetBeatValue());
    }
}
