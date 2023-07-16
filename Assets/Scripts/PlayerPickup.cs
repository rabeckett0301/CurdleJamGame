using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    GameObject heldItem;
    [SerializeField] LayerMask pickupableMask;
    [SerializeField] Transform holdPoint;
    [SerializeField] float range;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !heldItem)
        {
            ContactFilter2D contactFilter2D = new();
            contactFilter2D.SetLayerMask(pickupableMask);
            Collider2D[] results = new Collider2D[1];
            Physics2D.OverlapCircle(transform.position, range, contactFilter2D, results);
            results[0].GetComponent<IPickupable>().Pickup(holdPoint);
            heldItem = results[0].gameObject;
            heldItem.transform.SetParent(holdPoint);
            heldItem.transform.localPosition = Vector2.zero;
        }
        else if(Input.GetKeyDown(KeyCode.E) && heldItem)
        {
            heldItem.GetComponent<IPickupable>().Drop();
            heldItem.transform.SetParent(null);
            heldItem = null;
        }
    }
}
