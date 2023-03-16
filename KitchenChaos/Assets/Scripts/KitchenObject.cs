using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    private ClearCounter clearCounter;
    [SerializeField] private KitchenObjectsSO kitchenObjectsSO;

    public KitchenObjectsSO GetKitchenObjectsSO()
    {
        return kitchenObjectsSO;
    }

    public ClearCounter GetClearCounter()
    {
        return this.clearCounter;
    }

    public void SetClearCounter(ClearCounter clearCounter)
    {
        if (this.clearCounter != null)
        {
            this.clearCounter.ClearKitchenObject();
        }

        this.clearCounter = clearCounter;
        clearCounter.SetKitchenObject(this);
        
        transform.parent = clearCounter.GetKitchenObjectFollowParent();
        transform.localPosition = Vector3.zero;
    }
}