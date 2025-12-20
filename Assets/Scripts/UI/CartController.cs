using System;
using System.Collections.Generic;
using Architecture;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace UI
{
    /// <summary>
    /// 挂在购物车，负责显示购物车内的物品及总价
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class CartController : MonoBehaviour
    {
        [SerializeField] private RectTransform cartItemsContainer;
        [SerializeField] private FoodDisplay cartItemPrefab;
        [SerializeField] private TextMeshProUGUI cartTotalPrice;
        
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            Assert.IsNotNull(_canvasGroup);
            EventsManager.Instance.AddEventsListener<List<FoodItem>>(Constants.CartUIRefreshEvent, RefreshCartItems);
        }

        private void OnEnable()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
            RefreshCartItems(GameManager.Instance.ShoppingCartItems);
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
        
        public void ShowCart()
        {
            gameObject.SetActive(true);
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }
        
        public void HideCart()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
            gameObject.SetActive(false);
        }
    }
}