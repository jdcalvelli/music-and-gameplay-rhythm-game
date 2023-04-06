using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeansController : CondimentController, IOnKey_PEvent, IOnBarEvent
{

    [SerializeField] private CondimentView beansView;
    
    private void Start()
    {
        InputManager.Instance.OnKey_P += OnKey_PEvent;
        MusicManager.Instance.OnBar += OnBarEvent;
    }

    public void OnKey_PEvent(object sender, EventArgs e)
    {
        // need to check if on beat in general and on the right beat specifically
        if (UsedOnBeat() && BeatTracker.Instance.BeatValue == 4)
        {
            //Debug.Log("-- on beat --");
            beansView.SqueezeBottle();
            GameManager.Instance.CurrentHotDog.AddCondiment("Beans");
        }
        else
        {
            //Debug.Log("-- not on beat --");
            beansView.ShakeBottle();
        }
    }
    
    // on bar event can be moved into parent class perhaps
    public void OnBarEvent(object sender, EventArgs e)
    {
        if (GameManager.Instance.CurrentHotDog.OrderModel.CondimentList["Beans"])
        {
            // set color to green in view
            beansView.ChangeColor(Color.green);
        }
        else
        {
            //set color to red in view
            beansView.ChangeColor(Color.white);
        }
    }
}
