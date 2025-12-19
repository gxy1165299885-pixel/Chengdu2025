using System.Collections.Generic;
using GamePlay;
using UnityEngine;

namespace Architecture
{
    public class GameManager : SingletonMono<GameManager>
    {
        public int dayCount = 0;
        public int PlayerHungry = 15;
        public int PlayerHealth = 100;
        public int PlayerMoney = 10;
        public List<ICoupon> PlayerCoupons = new List<ICoupon>();
        
        public void DisplayMainScene()
        {
            
        }

        public void StartGame()
        {
            //开始游戏时会+1天
            dayCount = 0;
            PlayerHealth = 100;
            EventsManager.Instance.EventClear();
            EventsManager.Instance.AddEventsListener<FoodItem>(Constants.PlayerEatEvent, OnPlayerEat);
            
            StartDay();
        }

        private void OnPlayerEat(FoodItem foodItem)
        {
            //PlayerHungry += foodItem.Hungry;
            
        }

        public void StartDay()
        {
            dayCount += 1;
            EventsManager.Instance.EventTrigger(Constants.DayStartEvent, dayCount);
        }

        public void EndDay()
        {
            EventsManager.Instance.EventTrigger(Constants.DayEndEvent, dayCount);
        }
        
        public void ChangePlayerHealth(int delta)
        {
            PlayerHealth += delta;
        }
        
        
        
        public void GetCoupon(ICoupon coupon)
        {
            PlayerCoupons.Add(coupon);
        }
        
        public void RemoveCoupon(ICoupon coupon)
        {
            PlayerCoupons.Remove(coupon);
        }
        
        public void ClearCoupons()
        {
            PlayerCoupons.Clear();
        }
    }
}