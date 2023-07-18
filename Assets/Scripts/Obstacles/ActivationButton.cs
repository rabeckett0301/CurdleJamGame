using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationButton : MonoBehaviour
{
    [SerializeField] GameObject objectToActivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objectToActivate.GetComponent<IActivatable>().Activate();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        objectToActivate.GetComponent<IActivatable>().Deactivate();
    }
}