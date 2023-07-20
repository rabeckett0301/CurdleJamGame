using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    GameObject heldItem;
    IPickupable selectedItem;
    PlayerMovement playerMovement;
    [SerializeField] LayerMask pickupableMask;
    [SerializeField] Transform holdPoint;
    [SerializeField] GameObject dropPoint;
    [SerializeField] float range;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!heldItem)
        {
            if (TryCheckForPickupableInRange())
            {
                selectedItem.Selected = true;
            }
            else
            {
                if (selectedItem != null)
                {
                    selectedItem.Selected = false;
                    selectedItem = null;
                }
            }
        }
        else
        {
            if(playerMovement.lookDirection == LookDirection.LEFT)
            {
                dropPoint.transform.localPosition = new Vector3(-1.25f, 0.75f);
            }
            else
            {
                dropPoint.transform.localPosition = new Vector3(1.25f, 0.75f);
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && !heldItem)
        {
            if (selectedItem == null)
            {
                return;
            }

            selectedItem.Pickup(holdPoint);
            heldItem = selectedItem.GetGameObject();
            heldItem.transform.SetParent(holdPoint);
            heldItem.transform.localPosition = Vector2.zero;
            selectedItem.Selected = false;
            selectedItem = null;
            dropPoint.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.E) && heldItem)
        {
            heldItem.GetComponent<IPickupable>().Drop(dropPoint.transform);
            heldItem.transform.SetParent(null);
            heldItem = null;
            dropPoint.SetActive(false);
        }
    }

    bool TryCheckForPickupableInRange()
    {
        ContactFilter2D contactFilter2D = new();
        contactFilter2D.SetLayerMask(pickupableMask);
        contactFilter2D.useTriggers = true;
        RaycastHit2D[] results = new RaycastHit2D[1];

        Vector2 direction = new();

        if (playerMovement.lookDirection == LookDirection.LEFT)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.right;
        }

        Physics2D.Raycast(transform.position, direction, contactFilter2D, results, range);

        if (!results[0])
        {
            return false;
        }

        selectedItem = results[0].transform.gameObject.GetComponent<IPickupable>();

        return true;
    }
}
