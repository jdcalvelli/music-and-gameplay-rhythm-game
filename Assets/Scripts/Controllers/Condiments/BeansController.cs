using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeansController : CondimentController, IOnKey_PEvent
{

    [SerializeField] private CondimentView beansView;
    
    private void Start()
    {
        InputManager.Instance.OnKey_P += OnKey_PEvent;
    }

    public void OnKey_PEvent(object sender, EventArgs e)
    {
        beansView.SqueezeBottle();
        AddCondiment("Beans");
    }
}
