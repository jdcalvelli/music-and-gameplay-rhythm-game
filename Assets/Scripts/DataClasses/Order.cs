using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order
{
    public Dictionary<string, bool> CondimentList = new Dictionary<string, bool>()
    {
        { "Ketchup", false },
        { "Mustard", false },
        { "Relish", false },
        { "Beans", false },
    };
}
