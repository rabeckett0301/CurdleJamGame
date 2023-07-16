using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickupable
{
    public void Pickup(Transform holdPoint);

    public void Drop();

    public bool BeingCarried { get; set; }

    public Transform HoldPoint { get; set; }
}
