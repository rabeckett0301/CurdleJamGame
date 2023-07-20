using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour, IActivatable
{
    [Tooltip("ACTIVATE makes the bridge appear when the activating button is pressed. DEACTIVATE makes the bridge disappear when the buton is pressed.")]
    [SerializeField] ActivationMode activationMode;

    private void Start()
    {
        if(activationMode == ActivationMode.ACTIVATE)
        {
            SetBridgesActive(false);
        }
        else
        {
            SetBridgesActive(true);
        }
    }

    public void Activate()
    {
        if (activationMode == ActivationMode.ACTIVATE)
        {
            SetBridgesActive(true);
        }
        else
        {
            SetBridgesActive(false);
        }

        
    }

    public void Deactivate()
    {
        if (activationMode == ActivationMode.ACTIVATE)
        {
            SetBridgesActive(false);
        }
        else
        {
            SetBridgesActive(true);
        }
    }

    public void SetBridgesActive(bool state)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(state);
        }
    }
}

public enum ActivationMode
{
    ACTIVATE,
    DEACTIVATE
}