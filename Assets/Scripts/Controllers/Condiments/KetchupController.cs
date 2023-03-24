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
        // need to check if on beat in general and on the right beat specifically
        if (UsedOnBeat() && BeatTracker.Instance.BeatValue == 1)
        {
            //Debug.Log("-- on beat --");
            ketchupView.SqueezeBottle();
            AddCondiment("Ketchup");
        }
        else
        {
            //Debug.Log("-- not on beat --");
            ketchupView.ShakeBottle();
        }
    }
}
