using System;
using System.Collections.Generic;
using UI;
using UnityEngine;
using Yarn.Unity;

namespace Architecture
{
    public class GameManager : SingletonMono<GameManager>
    {
        [SerializeField] private Canvas mainGameCanvas;
        
        public int dayCount = 0;
        
        public int PlayerHungry = 15;
        public const int MaxPlayerHungry = 15;
        
        public int PlayerHealth = 10;
        public const int MaxPlayerHealth = 10;
        
        public int PlayerHappy = 10;
        
        public int PlayerMoney = 10;
        
        public List<FoodItem> ShoppingCartItems = new ();
        
        public List<DiscountItem> PlayerDiscountItems = new()
        {
            new DiscountItem(),
            new DiscountItem()
        };
        public List<DiscountItem> UsingDiscountItems = new ();

        public List<FoodItem> PlayerAteItems = new();

        [YarnCommand("DisplayMainScene")]
        public static void DisplayMainScene()
        {
            GameManager.Instance.mainGameCanvas.gameObject.SetActive(true);
            GameManager.Instance.StartGame();
        }

        public void StartGame()
        {
            //开始游戏时会+1天
            dayCount = 0;
            PlayerHealth = MaxPlayerHealth;
            PlayerHungry = MaxPlayerHungry;
            PlayerHappy = 0;
            PlayerMoney = 200;
            
            StartDay();
        }

        private void OnPlayerEat(List<FoodItem> foodItems)
        {
            foreach (var foodItem in foodItems)
            {
                var item = new FoodItem(foodItem);
                PlayerHungry += item.Hungry;
                PlayerHealth += item.Health;
                PlayerAteItems.Add(item);
            }
        }

        public void StartDay()
        {
            dayCount += 1;
            EventsManager.Instance.EventTrigger(Constants.DayStartEvent, dayCount);
        }

        public void EndDay()
        {
            EventsManager.Instance.EventTrigger(Constants.DayEndEvent, dayCount);

            if (dayCount == 14)
            {
                EventsManager.Instance.EventTrigger(Constants.GameEndEvent);
            }
        }
        
        public void GetCoupon(DiscountItem coupon)
        {
            PlayerDiscountItems.Add(coupon);
        }
        
        public void RemoveCoupon(DiscountItem coupon)
        {
            PlayerDiscountItems.Remove(coupon);
        }
        
        public void ClearCoupons()
        {
            PlayerDiscountItems.Clear();
        }
        
        private void OnEnable()
        {
            EventsManager.Instance.AddEventsListener<List<FoodItem>>(Constants.PlayerEatEvent, OnPlayerEat);
        }

        private void OnDisable()
        {
            EventsManager.Instance.RemoveListener<List<FoodItem>>(Constants.PlayerEatEvent, OnPlayerEat);
        }
    }
}