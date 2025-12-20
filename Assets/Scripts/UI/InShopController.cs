using System;
using System.Collections.Generic;
using Architecture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// 进入外卖店，负责显示店铺信息及店内菜品
    /// </summary>
    public class InShopController : MonoBehaviour
    {
        [SerializeField] private Image shopIconImage;
        [SerializeField] private TextMeshProUGUI shopNameText;
        [SerializeField] private TextMeshProUGUI shopDescriptionText;
        [SerializeField] private RectTransform foodItemsContainer;
        [SerializeField] private FoodDisplay foodItemPrefab;
        [SerializeField] private AddToCartTip addToCartTipPrefab;
        
        public void SetShopInfo(Sprite shopIcon, string shopName, string shopDescription,List<FoodItem> foods)
        {
            shopIconImage.sprite = shopIcon;
            shopNameText.text = shopName;
            shopDescriptionText.text = shopDescription;

            foreach (Transform t in foodItemsContainer)
            {
                Destroy(t.gameObject);
            }

            foreach (var food in foods)
            {
                Instantiate(foodItemPrefab, foodItemsContainer).SetFoodInfo(food);
            }
        }

        private void OnEnable()
        {
            EventsManager.Instance.AddEventsListener(Constants.ShowAddToCartTipEvent,ShowAddToCartTip);
        }

        public void ShowAddToCartTip()
        {
            Instantiate(addToCartTipPrefab, transform).ShowTip();
        }
    }
}