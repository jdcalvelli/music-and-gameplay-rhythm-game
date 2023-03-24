using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CondimentController : MonoBehaviour
{
    // check if on beat should be here too i think
    
    public void AddCondiment(string condimentName)
    {
        GameManager.Instance.CurrentHotDog._hotDog.CondimentList[condimentName] = true;
    }

    public bool UsedOnBeat()
    {
        // save input time
        int inputTime = MusicManager.Instance.NormalizedCurrentPlaybackTime;
        
        //Debug.Log("input time " + inputTime);
        //Debug.Log("early window " + (BeatTracker.Instance.NextBeatTime - BeatTracker.Instance.TWindow));
        //Debug.Log("late window " + (BeatTracker.Instance.NextBeatTime + BeatTracker.Instance.TWindow));
        
        // if input is within next beat plus minus tolerance window
        if (inputTime >= BeatTracker.Instance.BeatTime - BeatTracker.Instance.TWindow 
            && inputTime <= BeatTracker.Instance.BeatTime + BeatTracker.Instance.TWindow)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
