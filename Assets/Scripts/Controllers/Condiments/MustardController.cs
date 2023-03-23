using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MustardController : CondimentController, IOnKey_WEvent
{

    [SerializeField] private CondimentView mustardView;
    
    private void Start()
    {
        InputManager.Instance.OnKey_W += OnKey_WEvent;
    }

    public void OnKey_WEvent(object sender, EventArgs e)
    {
        mustardView.SqueezeBottle();
        AddCondiment("Mustard");
    }
}
