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
    
    
}
