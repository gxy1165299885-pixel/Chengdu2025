using System.Collections.Generic;
using GamePlay;
using UnityEngine;

namespace Architecture
{
    public class GameManager : SingletonMono<GameManager>
    {
        public int dayCount = 0;
        public int PlayerHealth = 100;
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
            EventsManager.Instance.AddEventsListener(Constants.PlayerHealthChangedEvent,OnPlayerHealthChanged);
            StartDay();
        }

        public void StartDay()
        {
            dayCount += 1;
            EventsManager.Instance.EventTrigger(Constants.DayStartEvent, dayCount);
        }
        
        public void OnPlayerHealthChanged()
        {
            // 可以在这里处理玩家生命值变化的逻辑
            Debug.Log("Player Health changed to: " + PlayerHealth);
            if (PlayerHealth <= 0)
            {
                EventsManager.Instance.EventTrigger(Constants.PlayerDeadEvent);
            }
        }

        public void EndDay()
        {
            EventsManager.Instance.EventTrigger(Constants.DayEndEvent, dayCount);
        }
        
        public void ChangePlayerHealth(int delta)
        {
            PlayerHealth += delta;
            EventsManager.Instance.EventTrigger(Constants.PlayerHealthChangedEvent, PlayerHealth);
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