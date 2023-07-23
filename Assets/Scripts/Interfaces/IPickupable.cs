using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickupable
{
    public bool TryPickup(Transform holdPoint);

    public void Drop(Transform dropPoint);

    public void DisplayPickupablePointer();

    public void HidePickupablePointer();

    public GameObject GetGameObject();

    public void SetLastLookedLeft(bool lastLookedLeft);

    public bool BeingCarried { get; set; }

    public Transform HoldPoint { get; set; }

    public bool Selected { get; set; }

    public bool CanBeCarried { get; set; }
}
