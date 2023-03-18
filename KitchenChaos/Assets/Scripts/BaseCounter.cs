using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectsParent
{
    [SerializeField] private Transform counterTopPoint;

    protected KitchenObject kitchenObject;
    public virtual void Interact(Player player)
    {
        Debug.LogError("BaseCounter");
    }
    public virtual void InteractAlternate(Player player)
    {
        Debug.LogError("BaseCounter Alternate");
    }


    public Transform GetKitchenObjectFollowParent()
    {
        return counterTopPoint;
    }


    public void ClearKitchenObject()
    {
        this.kitchenObject = null;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }
    public KitchenObject GetKitchenObject()
    {
        return this.kitchenObject;
    }
    public bool HasAKitchenObject()
    {
        return this.kitchenObject != null;
    }

}
