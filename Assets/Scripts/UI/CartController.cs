using System;
using System.Collections.Generic;
using Architecture;
using TMPro;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// 挂在购物车，负责显示购物车内的物品及总价
    /// </summary>
    public class CartController : MonoBehaviour
    {
        [SerializeField] private RectTransform cartItemsContainer;
        [SerializeField] private FoodDisplayController cartItemPrefab;
        [SerializeField] private TextMeshProUGUI cartTotalPrice;

        private void OnEnable()
        {
            EventsManager.Instance.AddEventsListener<List<FoodItem>>(Constants.CartUIRefreshEvent, RefreshCartItems);
        }

        private void OnDisable()
        {
            EventsManager.Instance.RemoveListener<List<FoodItem>>(Constants.CartUIRefreshEvent, RefreshCartItems);
        }

        /// <summary>
        /// 监听事件CartUIRefreshEvent，刷新购物车内的物品显示及总价
        /// </summary>
        public void RefreshCartItems(List<FoodItem> cartItems)
        {
            foreach (Transform child in cartItemsContainer)
            {
                Destroy(child.gameObject);
            }

            int totalPrice = 0;

            foreach (var item in cartItems)
            {
                Instantiate(cartItemPrefab, cartItemsContainer).SetFoodInfo(item);
                totalPrice += item.FoodPrice;
            }
            
            cartTotalPrice.text = $"Total: {totalPrice:F2}¥";
        }
    }
}