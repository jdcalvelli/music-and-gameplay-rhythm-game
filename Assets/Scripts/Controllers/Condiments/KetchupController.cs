using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KetchupController : CondimentController, IOnKey_QEvent
{

    [SerializeField] private CondimentView ketchupView;
    
    private void Start()
    {
        InputManager.Instance.OnKey_Q += OnKey_QEvent;
    }

    public void OnKey_QEvent(object sender, EventArgs e)
    {
        ketchupView.SqueezeBottle();
        AddCondiment("Ketchup");
    }
}
