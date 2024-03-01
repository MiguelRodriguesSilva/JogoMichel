using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public Controls inputActions;

    public void Awake()
    {
        inputActions = new Controls();
    }

    public void OnEnable()
    {
        inputActions.Enable();
    }

    public void OnDisable()
    {
        inputActions.Disable();
    }
}
