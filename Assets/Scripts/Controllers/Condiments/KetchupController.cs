using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KetchupController : CondimentController, IOnKey_QEvent, IOnBarEvent
{

    [SerializeField] private CondimentView ketchupView;
    
    private void Start()
    {
        InputManager.Instance.OnKey_Q += OnKey_QEvent;
        MusicManager.Instance.OnBar += OnBarEvent;
    }

    public void OnKey_QEvent(object sender, EventArgs e)
    {
        // need to check if on beat in general and on the right beat specifically
        if (UsedOnBeat() && BeatTracker.Instance.BeatValue == 1)
        {
            //Debug.Log("-- on beat --");
            ketchupView.SqueezeBottle();
            GameManager.Instance.CurrentHotDog.AddCondiment("Ketchup");
        }
        else
        {
            //Debug.Log("-- not on beat --");
            ketchupView.ShakeBottle();
        }
    }
    
    // on bar event can be moved into parent class perhaps
    public void OnBarEvent(object sender, EventArgs e)
    {
        if (GameManager.Instance.CurrentHotDog.OrderModel.CondimentList["Ketchup"])
        {
            // set color to green in view
            ketchupView.ChangeColor(Color.green);
        }
        else
        {
            //set color to red in view
            ketchupView.ChangeColor(Color.white);
        }
    }
}
