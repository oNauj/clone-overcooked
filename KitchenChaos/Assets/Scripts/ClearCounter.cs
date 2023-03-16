using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectsParent
{
    [SerializeField] private KitchenObjectsSO kitchenObjectsSO;
    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kitchenObject;
    private bool testing = true;
    public ClearCounter secondClearCounter;

    private void Update()
    {
        if (Input.GetKey(KeyCode.T) && testing == true)
        {
            if (kitchenObject != null)
            {
                kitchenObject.SetKitchenObjectParent(secondClearCounter);
            }
        }
    }
    public void Interact(Player player)
    {
        if (kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectsSO.prefab, counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
            kitchenObjectTransform.localPosition = Vector3.zero;
        }
        else
        {
            kitchenObject.SetKitchenObjectParent(player);
        }
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
