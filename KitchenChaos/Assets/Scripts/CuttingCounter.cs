using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingObjectsSO[] cuttingObjectsSOArray;

    private int cuttingProgress;

    public EventHandler<OnProgressChangedEventArgs> OnProgressChanged;

    public class OnProgressChangedEventArgs : EventArgs
    {
        public float progressNormalized;
    }

    public EventHandler OnCut;
    public override void Interact(Player player)
    {
        if (!HasAKitchenObject())
        {
            if (player.HasAKitchenObject())
            {
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectsSO()))
                {
                    player.GetKitchenObject().SetKitchenObjectParent(this);

                    cuttingProgress = 0;

                    CuttingObjectsSO cuttingObjectsSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectsSO());


                    OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
                    {
                        progressNormalized = (float)cuttingProgress / cuttingObjectsSO.cuttingProgressMax
                    });
                }
            }
        }
        else
        {
            if (!player.HasAKitchenObject())
            {
                this.GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void InteractAlternate(Player player)
    {

        if (HasAKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectsSO()))
        {
            cuttingProgress++;

            CuttingObjectsSO cuttingObjectsSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectsSO());

            OnCut?.Invoke(this, EventArgs.Empty);    
            OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
            {
                progressNormalized = (float)cuttingProgress / cuttingObjectsSO.cuttingProgressMax
            });
            if (cuttingProgress >= cuttingObjectsSO.cuttingProgressMax)
            {
                cuttingProgress = 0;
                KitchenObjectsSO outputCuttingKitchenobject = GetOutputForInput(GetKitchenObject().GetKitchenObjectsSO());
                GetKitchenObject().DestroySelf();
                KitchenObject.SpawnKitchenObject(outputCuttingKitchenobject, this);
            }

        }
    }


    private bool HasRecipeWithInput(KitchenObjectsSO inputKitchenObjectsSO)
    {
        CuttingObjectsSO cuttingObjectsSO = GetCuttingRecipeSOWithInput(inputKitchenObjectsSO);
        return cuttingObjectsSO != null;
    }
    private KitchenObjectsSO GetOutputForInput(KitchenObjectsSO inputKitchenObjectsSO)
    {
        CuttingObjectsSO cuttingObjectsSO = GetCuttingRecipeSOWithInput(inputKitchenObjectsSO);
        if (cuttingObjectsSO != null)
        {
            return cuttingObjectsSO.output;
        }
        else
        {
            return null;
        }

    }

    private CuttingObjectsSO GetCuttingRecipeSOWithInput(KitchenObjectsSO inputKitchenObjectsSO)
    {
        foreach (CuttingObjectsSO cuttingObjectsSO in cuttingObjectsSOArray)
        {
            if (cuttingObjectsSO.input == inputKitchenObjectsSO)
            {
                return cuttingObjectsSO;
            }
        }
        return null;
    }
}
