using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    float range = 2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ContactFilter2D contactFilter2D = new();
            Collider2D[] results = new Collider2D[10];
            Physics2D.OverlapCircle(transform.position, range, contactFilter2D, results);
            
            foreach(Collider2D collider in results)
            {
                if (collider.gameObject.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact();
                    break;
                }
            }
        }
    }
}
