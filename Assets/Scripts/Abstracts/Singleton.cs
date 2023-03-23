using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    
    // singleton insurance, private set
    public static T Instance { get; private set; }

    // set to virtual in case we need to override to add particular things in subclasses
    public virtual void Awake()
    {
        // singleton insurance, only one present
        if (Instance != null && Instance != this as T)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this as T;
        }
    }
}
