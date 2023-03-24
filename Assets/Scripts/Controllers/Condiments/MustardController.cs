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
        // need to check if on beat in general and on the right beat specifically
        if (UsedOnBeat() && BeatTracker.Instance.BeatValue == 2)
        {
            //Debug.Log("-- on beat --");
            mustardView.SqueezeBottle();
            GameManager.Instance.CurrentHotDog.AddCondiment("Mustard");
        }
        else
        {
            //Debug.Log("-- not on beat --");
            mustardView.ShakeBottle();
        }
    }
}
