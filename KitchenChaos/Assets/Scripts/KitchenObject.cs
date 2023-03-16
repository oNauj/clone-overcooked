using UnityEngine;

public class KitchenObject : MonoBehaviour
{

    [SerializeField] private KitchenObjectsSO kitchenObjectsSO;

    private IKitchenObjectsParent kitchenObjectParent;

    public KitchenObjectsSO GetKitchenObjectsSO()
    {
        return kitchenObjectsSO;
    }

    public void SetKitchenObjectParent(IKitchenObjectsParent kitchenObjectsParent)
    {
        if (this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }

        this.kitchenObjectParent = kitchenObjectsParent;

        if (kitchenObjectParent.HasAKitchenObject()) Debug.LogError("KitchenParent already has a KitchenObject");


        kitchenObjectsParent.SetKitchenObject(this);

        transform.parent = kitchenObjectsParent.GetKitchenObjectFollowParent();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectsParent GetKitchenObjectsParent()
    {
        return kitchenObjectParent;
    }
}