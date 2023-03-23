using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotDog
{
    // we need to track whether it has the condiments
    public Dictionary<string, bool> CondimentList = new Dictionary<string, bool>()
    {
        { "Ketchup", false },
        { "Mustard", false },
        { "Relish", false },
        { "Beans", false },
    };
}
