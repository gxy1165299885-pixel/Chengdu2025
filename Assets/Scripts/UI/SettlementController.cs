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
            
            EventsManager.Instance.AddEventsListener<int>(Constants.DayEndEvent,OnDayEnd);
        }

        private void OnDisable()
        {
            EventsManager.Instance.RemoveListener<int>(Constants.DayEndEvent,OnDayEnd);
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