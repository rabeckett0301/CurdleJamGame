using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationButton : MonoBehaviour
{
    [SerializeField] GameObject objectToActivate;

    [SerializeField] Sprite pushedButton;
    [SerializeField] Sprite releasedButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objectToActivate.GetComponent<IActivatable>().Activate();
        GetComponentInChildren<SpriteRenderer>().sprite = pushedButton;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        objectToActivate.GetComponent<IActivatable>().Deactivate();
        GetComponentInChildren<SpriteRenderer>().sprite = releasedButton;
    }
}
