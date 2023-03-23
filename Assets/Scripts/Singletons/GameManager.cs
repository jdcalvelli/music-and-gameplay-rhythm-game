using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    // holder for hot dog
    private HotDog _currentHotDog;

    private void Start()
    {
        // instantiate a hot dog for testing
        _currentHotDog = new HotDog();
        _currentHotDog.AddCondiment("Ketchup");
        _currentHotDog.AddCondiment("Relish");

        // showing condiments
        foreach (var condiment in _currentHotDog.GetCondiments())
        {
            Debug.Log(condiment);
        }
    }

    private void Update()
    {
        Debug.Log(BeatTracker.Instance.GetBeatValue());
    }
}
