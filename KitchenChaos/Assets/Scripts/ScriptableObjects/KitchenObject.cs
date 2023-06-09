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

    public bool TryGetPlate(out PlateKitchenObject plateKitchenObject)
    {
        if (this is PlateKitchenObject)
        {
            plateKitchenObject = this as PlateKitchenObject;
            return true;
        }
        else
        {
            plateKitchenObject = null;
            return false;
        }
    }

    public IKitchenObjectsParent GetKitchenObjectsParent()
    {
        return kitchenObjectParent;
    }

    public void DestroySelf()
    {
        kitchenObjectParent.ClearKitchenObject();
        Destroy(gameObject);
    }

    public static KitchenObject SpawnKitchenObject(KitchenObjectsSO kitchenObjectsSO, IKitchenObjectsParent kitchenObjectsParent)
    {
        Transform kitchenObjectTransform = Instantiate(kitchenObjectsSO.prefab);

        KitchenObject kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();

        kitchenObject.SetKitchenObjectParent(kitchenObjectsParent);

        return kitchenObject;
    }
}