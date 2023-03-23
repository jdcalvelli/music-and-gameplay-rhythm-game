using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotDog
{
    // we need to track whether it has the condiments
    private Dictionary<string, bool> _condimentList = new Dictionary<string, bool>()
    {
        {"Ketchup", false},
        {"Mustard", false},
        {"Relish", false},
        {"Beans", false},
    };
    
    // add condiment
    public void AddCondiment(string condiment)
    {
        _condimentList[condiment] = true;
    }

    public Dictionary<string, bool> GetCondiments()
    {
        return _condimentList;
    }
}
