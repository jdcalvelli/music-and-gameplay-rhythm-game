using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HotDogController : MonoBehaviour, IOnBeatEvent, IOnBarEvent
{

    [SerializeField] private HotDogView hotDogView;
    
    // super dirty
    [SerializeField] private SmileDirtyView smileDirtyView;
    [SerializeField] private FrownDirtyView frownDirtyView;
    
    public HotDog HotDogModel = new HotDog();
    public Order OrderModel = new Order();
    void Start()
    {
        // subscribe to events
        MusicManager.Instance.OnBeat += OnBeatEvent;
        MusicManager.Instance.OnBar += OnBarEvent;
        
        // need to randomize order
        RandomizeOrder();
    }

    public void OnBeatEvent(object sender, EventArgs e)
    {
        // call view code to move the glizzy
        hotDogView.MoveGlizzy(BeatTracker.Instance.BeatValue);
    }

    public void OnBarEvent(object sender, EventArgs e)
    {
        // all of this should move into the game manager logic, but crunch
        // first check if dictionaries are equal
        bool dictionariesEqual = 
            HotDogModel.CondimentList.Keys.Count == OrderModel.CondimentList.Keys.Count &&
            HotDogModel.CondimentList.Keys.All(k => OrderModel.CondimentList.ContainsKey(k) && 
                                                    object.Equals(OrderModel.CondimentList[k], 
                                                        HotDogModel.CondimentList[k]));
        if (dictionariesEqual)
        {
            Debug.Log("order correct!");
            smileDirtyView.FadeSmile();
        }
        else
        {
            Debug.Log("order incorrect!");
            frownDirtyView.FadeFrown();
        }

        hotDogView.RemoveGlizzyCondiments();
        HotDogModel = new HotDog();
        OrderModel = new Order();
        RandomizeOrder();
    }
    
    public void AddCondiment(string condimentName)
    {
        // update the model
        GameManager.Instance.CurrentHotDog.HotDogModel.CondimentList[condimentName] = true;
        // update the condiment view
        hotDogView.ShowGlizzyCondiment(condimentName);
    }

    public void RandomizeOrder()
    {
        foreach (var orderKey in OrderModel.CondimentList.Keys.ToList())
        {
            switch (UnityEngine.Random.Range(0, 2))
            {
                case 0:
                    OrderModel.CondimentList[orderKey] = false;
                    break;
                case 1:
                    OrderModel.CondimentList[orderKey] = true;
                    break;
            }
        }
    }
}
