using System;
using System.Collections.Generic;
using Architecture;
using UnityEngine;

namespace UI
{
    public class CartController : MonoBehaviour
    {
        [SerializeField] private RectTransform cartItemsContainer;
        [SerializeField] private FoodDisplayController cartItemPrefab;

        private void Awake()
        {
            EventsManager.Instance.AddEventsListener<List<FoodItem>>(Constants.CartUIRefreshEvent, RefreshCartItems);
        }

        public void RefreshCartItems(List<FoodItem> cartItems)
        {
            foreach (Transform child in cartItemsContainer)
            {
                Destroy(child.gameObject);
            }

            foreach (var item in cartItems)
            {
                Instantiate(cartItemPrefab, cartItemsContainer).SetFoodInfo(item);
            }
        }
    }
}