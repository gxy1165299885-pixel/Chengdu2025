using System.Collections.Generic;
using Architecture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class FoodDisplayController : MonoBehaviour
    {
        [SerializeField] private Image foodIcon;
        [SerializeField] private TextMeshProUGUI foodNameText;
        [SerializeField] private TextMeshProUGUI foodDescriptionText;
        [SerializeField] private TextMeshProUGUI foodPriceText;
        
        private FoodItem _foodRef;
        
        public void SetFoodInfo(FoodItem food)
        {
            _foodRef = food;
            foodIcon.sprite = ResourceManager.Instance.Load<Sprite>(food.FoodIconName);
            foodNameText.text = food.FoodName;
            foodDescriptionText.text = food.FoodDescription;
            foodPriceText.text = $"Total: {food.FoodPrice:F2}¥";
        }
        
        public void AddShoppingCart()
        {
            GameManager.Instance.ShoppingCartItems.Add(_foodRef);
            EventsManager.Instance.EventTrigger<List<FoodItem>>(Constants.CartUIRefreshEvent,
                GameManager.Instance.ShoppingCartItems);
        }
        
        public void DeleteFromShoppingCart()
        {
            GameManager.Instance.ShoppingCartItems.Remove(_foodRef);
            EventsManager.Instance.EventTrigger<List<FoodItem>>(Constants.CartUIRefreshEvent,
                GameManager.Instance.ShoppingCartItems);
        }
    }
}