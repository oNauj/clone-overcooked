using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectsParent
{
    public Transform GetKitchenObjectFollowParent();

    public void ClearKitchenObject();


    public void SetKitchenObject(KitchenObject kitchenObject);

    public KitchenObject GetKitchenObject();

    public bool HasAKitchenObject();


}
