using System;
using System.Collections.Generic;
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
            Refresh(new List<FoodItem>());

            EventsManager.Instance.AddEventsListener<int>(Constants.DayEndEvent,OnDayEnd);
            EventsManager.Instance.AddEventsListener<List<FoodItem>>(Constants.CartUIRefreshEvent,Refresh);
        }

        private void Refresh(List<FoodItem> _)
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
            EventsManager.Instance.RemoveListener<int>(Constants.DayEndEvent,OnDayEnd);
            EventsManager.Instance.RemoveListener<List<FoodItem>>(Constants.CartUIRefreshEvent,Refresh);
        }
        
        private void OnDayEnd(int dayEnd)
        {
            foreach (Transform t in foodItemsContainer)
            {
                Destroy(t.gameObject);
            }
            gameObject.SetActive(false);
            Debug.Log("第"+dayEnd+"天结算界面关闭");
        }
    }
}