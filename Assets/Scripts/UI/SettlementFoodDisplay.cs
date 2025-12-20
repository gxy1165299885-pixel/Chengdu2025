using System.Collections.Generic;
using Architecture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SettlementFoodDisplay : MonoBehaviour
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
            foodPriceText.text = $"{food.FoodPrice:F2}¥";
        }
    }
}