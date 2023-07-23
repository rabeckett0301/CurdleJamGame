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

    bool beingPressed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!beingPressed)
        {
            objectToActivate.GetComponent<IActivatable>().Activate();
            GetComponentInChildren<SpriteRenderer>().sprite = pushedButton;
            GetComponent<AudioSource>().PlayOneShot(pushedClip, 0.3f);
        }
        beingPressed = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (beingPressed)
        {
            ContactFilter2D contactFilter2D = new();
            Collider2D[] results = new Collider2D[10];
            int hits = Physics2D.OverlapPoint(transform.position, contactFilter2D, results);

            if(hits > 0)
            {
                return;
            }

            objectToActivate.GetComponent<IActivatable>().Deactivate();
            GetComponentInChildren<SpriteRenderer>().sprite = releasedButton;
            GetComponent<AudioSource>().PlayOneShot(releaseClip, 0.3f);
            beingPressed = false;
        }
        
    }
}
