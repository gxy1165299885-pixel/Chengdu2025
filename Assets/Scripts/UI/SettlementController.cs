using System;
using Architecture;
using UnityEngine;

namespace UI
{
    public class SettlementController : MonoBehaviour
    {
        [SerializeField] private Transform foodItemsContainer;
        [SerializeField] private SettlementFoodDisplay foodItemPrefab;

        private void OnEnable()
        {
            foreach (Transform t in foodItemsContainer)
            {
                Destroy(t.gameObject);
            }
            foreach (var food in GameManager.Instance.ShoppingCartItems)
            {
                Instantiate(foodItemPrefab, foodItemsContainer).SetFoodInfo(food);
            }
        }

        private void OnDisable()
        {
            throw new NotImplementedException();
        }
    }
}