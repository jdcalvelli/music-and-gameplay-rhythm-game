using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public event EventHandler OnKey_Q;
    public event EventHandler OnKey_W;
    public event EventHandler OnKey_O;
    public event EventHandler OnKey_P;

    // Update is called once per frame
    void Update()
    {

        // there must be a better way to do this
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnKey_Q!.Invoke(this, EventArgs.Empty);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            OnKey_W!.Invoke(this, EventArgs.Empty);
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            OnKey_O!.Invoke(this, EventArgs.Empty);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            OnKey_P!.Invoke(this, EventArgs.Empty);
        }

    }
    
}
