using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // singleton insurance, private set
    public static GameManager Instance { get; private set; }

    // holder for hot dog
    private HotDog _currentHotDog;
    
    private void Awake()
    {
        // singleton insurance
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        // instantiate a hot dog for testing
        _currentHotDog = new HotDog();
        _currentHotDog.addCondiment("Ketchup");
        _currentHotDog.addCondiment("Relish");

        foreach (var condiment in _currentHotDog.getCondiments())
        {
            Debug.Log(condiment);
        }
    }
}
