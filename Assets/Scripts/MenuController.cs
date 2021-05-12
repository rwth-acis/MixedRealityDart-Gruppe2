using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleSnapping()
    {
        var solverHandler = this.GetComponent(typeof(SolverHandler)) as SolverHandler;
        if (solverHandler != null)
        {
            if (!solverHandler.isActiveAndEnabled)
            {
                // Turn it on if it is already off
                solverHandler.enabled = true;
            }
            else
            {
                // Turn it off if it is already on
                solverHandler.enabled = false;
            }
        }
    }
}
