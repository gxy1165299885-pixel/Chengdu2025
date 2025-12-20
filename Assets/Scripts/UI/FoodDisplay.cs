using System.Collections.Generic;
using Architecture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// 挂在菜品上，负责显示菜品信息及添加/删除购物车功能
    /// </summary>
    public class FoodDisplay : MonoBehaviour
    {
        [SerializeField] private Image foodIcon;
        [SerializeField] private TextMeshProUGUI foodNameText;
        [SerializeField] private TextMeshProUGUI foodDescriptionText;
        [SerializeField] private TextMeshProUGUI foodPriceText;
        [SerializeField] private TextMeshProUGUI foodHungryText;
        
        private FoodItem _foodRef;
        
        public void SetFoodInfo(FoodItem food)
        {
            _foodRef = food;
            foodIcon.sprite = ResourceManager.Instance.Load<Sprite>(food.FoodIconName);
            foodNameText.text = food.FoodName;
            foodDescriptionText.text = food.FoodDescription;
            foodPriceText.text = $"{food.FoodPrice:F2}¥";
            foodHungryText.text = $"饱食度+{food.Hungry}";
        }
        
        public void AddShoppingCart()
        {
            GameManager.Instance.ShoppingCartItems.Add(_foodRef);
            EventsManager.Instance.EventTrigger<List<FoodItem>>(Constants.CartUIRefreshEvent,
                GameManager.Instance.ShoppingCartItems);
            EventsManager.Instance.EventTrigger(Constants.ShowAddToCartTipEvent);
        }
        
        public void DeleteFromShoppingCart()
        {
            GameManager.Instance.ShoppingCartItems.Remove(_foodRef);
            EventsManager.Instance.EventTrigger<List<FoodItem>>(Constants.CartUIRefreshEvent,
                GameManager.Instance.ShoppingCartItems);
        }
    }
}