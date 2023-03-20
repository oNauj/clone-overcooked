    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlateKitchenObject : KitchenObject {


        public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
        public class OnIngredientAddedEventArgs : EventArgs {
            public KitchenObjectsSO kitchenObjectSO;
        }


        [SerializeField] private List<KitchenObjectsSO> validKitchenObjectSOList;


        private List<KitchenObjectsSO> kitchenObjectSOList;


        private void Awake() {
            kitchenObjectSOList = new List<KitchenObjectsSO>();
        }

        public bool TryAddIngredient(KitchenObjectsSO kitchenObjectSO) {
            if (!validKitchenObjectSOList.Contains(kitchenObjectSO)) {
                // Not a valid ingredient
                return false;
            }
            if (kitchenObjectSOList.Contains(kitchenObjectSO)) {
                // Already has this type
                return false;
            } else {
                kitchenObjectSOList.Add(kitchenObjectSO);

                OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs {
                    kitchenObjectSO = kitchenObjectSO
                });

                return true;
            }
        }

        public List<KitchenObjectsSO> GetKitchenObjectSOList() {
            return kitchenObjectSOList;
        }

    }