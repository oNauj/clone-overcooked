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
        OnPlayerGrabbedObject?.Invoke(this,EventArgs.Empty);
        Transform kitchenObjectTransform = Instantiate(kitchenObjectsSO.prefab);
        kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
        kitchenObjectTransform.localPosition = Vector3.zero;
    }
}
