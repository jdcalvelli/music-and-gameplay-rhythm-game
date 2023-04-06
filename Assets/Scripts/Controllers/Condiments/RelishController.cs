using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelishController : CondimentController, IOnKey_OEvent, IOnBarEvent
{

    [SerializeField] private CondimentView relishView;
    
    private void Start()
    {
        InputManager.Instance.OnKey_O += OnKey_OEvent;
        MusicManager.Instance.OnBar += OnBarEvent;
    }

    public void OnKey_OEvent(object sender, EventArgs e)
    {
        // need to check if on beat in general and on the right beat specifically
        if (UsedOnBeat() && BeatTracker.Instance.BeatValue == 3)
        {
            //Debug.Log("-- on beat --");
            relishView.SqueezeBottle();
            GameManager.Instance.CurrentHotDog.AddCondiment("Relish");
        }
        else
        {
            //Debug.Log("-- not on beat --");
            relishView.ShakeBottle();
        }
    }
    
    // on bar event can be moved into parent class perhaps
    public void OnBarEvent(object sender, EventArgs e)
    {
        if (GameManager.Instance.CurrentHotDog.OrderModel.CondimentList["Relish"])
        {
            // set color to green in view
            relishView.ChangeColor(Color.green);
        }
        else
        {
            //set color to red in view
            relishView.ChangeColor(Color.white);
        }
    }
}
