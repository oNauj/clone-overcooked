using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{

    public static DeliveryManager Instance { get; private set; }
    [SerializeField] private RecipesListSO recipesListSO;
    private List<RecipeSO> waitingRecipeSOList;
    private float spawnRecipeTimer;
    private float spawnRecipeTimerMax = 6f;

    [SerializeField] private int waitingRecipeSOMax = 4;


    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;

    private void Awake()
    {
        waitingRecipeSOList = new List<RecipeSO>();
        Instance = this;
    }


    private void Update()
    {
        spawnRecipeTimer -= Time.deltaTime;

        if (spawnRecipeTimer <= 0f)
        {
            spawnRecipeTimer = spawnRecipeTimerMax;

            if (waitingRecipeSOList.Count < waitingRecipeSOMax)
            {
                RecipeSO waitingRecipeSO = recipesListSO.recipeSO[UnityEngine.Random.Range(0, recipesListSO.recipeSO.Count)];
                Debug.Log(waitingRecipeSO.recipeName);
                waitingRecipeSOList.Add(waitingRecipeSO);

                OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public void DeliverRecip(PlateKitchenObject plateKitchenObject)
    {
        for (int i = 0; i < waitingRecipeSOList.Count; i++)
        {
            RecipeSO waitingRecipeSO = waitingRecipeSOList[i];


            if (waitingRecipeSO.kitchenObjectsSOs.Count == plateKitchenObject.GetKitchenObjectSOList().Count)
            {
                bool plateContentsMatchesRecipe = true;
                foreach (KitchenObjectsSO recipeKitchenObjectsSO in waitingRecipeSO.kitchenObjectsSOs)
                {
                    bool ingredientFound = false;
                    foreach (KitchenObjectsSO plateKitchenObjectsSO in plateKitchenObject.GetKitchenObjectSOList())
                    {
                        if (plateKitchenObjectsSO == recipeKitchenObjectsSO)
                        {
                            //match
                            ingredientFound = true;
                            break;
                        }
                    }
                    if (!ingredientFound)
                    {
                        plateContentsMatchesRecipe = false;
                    }
                }
                if (plateContentsMatchesRecipe)
                {
                    waitingRecipeSOList.RemoveAt(i);
                    OnRecipeCompleted?.Invoke(this, EventArgs.Empty);
                    return;
                }
            }
        }
    }

    public List<RecipeSO> GetRecipesListSO()
    {
        return waitingRecipeSOList;
    }
}
