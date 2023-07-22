using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationButton : MonoBehaviour
{
    [SerializeField] GameObject objectToActivate;

    [SerializeField] Sprite pushedButton;
    [SerializeField] Sprite releasedButton;

    [SerializeField] AudioClip pushedClip;
    [SerializeField] AudioClip releaseClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objectToActivate.GetComponent<IActivatable>().Activate();
        GetComponentInChildren<SpriteRenderer>().sprite = pushedButton;
        GetComponent<AudioSource>().PlayOneShot(pushedClip, 0.3f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        objectToActivate.GetComponent<IActivatable>().Deactivate();
        GetComponentInChildren<SpriteRenderer>().sprite = releasedButton;
        GetComponent<AudioSource>().PlayOneShot(releaseClip, 0.3f);
    }
}
