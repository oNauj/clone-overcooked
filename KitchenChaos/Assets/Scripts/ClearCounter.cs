using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
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
                kitchenObject.SetClearCounter(secondClearCounter);
            }
        }
    }
    public void Interact()
    {
        if (kitchenObject == null)
        {
            Debug.Log("You are adding a " + kitchenObjectsSO.objectName);

            Transform kitchenObjectTransform = Instantiate(kitchenObjectsSO.prefab, counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetClearCounter(this);
            kitchenObjectTransform.localPosition = Vector3.zero;
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
