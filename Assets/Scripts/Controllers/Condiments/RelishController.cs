using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelishController : CondimentController, IOnKey_OEvent
{

    [SerializeField] private CondimentView relishView;
    
    private void Start()
    {
        InputManager.Instance.OnKey_O += OnKey_OEvent;
    }

    public void OnKey_OEvent(object sender, EventArgs e)
    {
        relishView.SqueezeBottle();
        AddCondiment("Relish");
    }
}
