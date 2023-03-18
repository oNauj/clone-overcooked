using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectsSO kitchenObjectsSO;

    public event EventHandler OnPlayerGrabbedObject;
    public override void Interact(Player player)
    {
        if (!player.HasAKitchenObject())
        {
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
            KitchenObject.SpawnKitchenObject(kitchenObjectsSO, player);
        }
    }
}
