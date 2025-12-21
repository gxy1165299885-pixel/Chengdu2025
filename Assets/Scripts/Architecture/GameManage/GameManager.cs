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
        public DialogueRunner dialogueRunner;
        
        private int _dayCount = 0;

        public int DayCount
        {
            get { return _dayCount; }
            set
            {
                _dayCount = value;
                EventsManager.Instance.EventTrigger(Constants.DayChangedEvent);
            }
        }
        
        public bool haveFreeCouponThisDay = false;
        public bool haveExchangeTimeThisDay = false;
        public int gachaTimesThisDay = 0;
        
        public bool todayFighting = false;
        public bool todayStolen = false;
        
        private int _hungryToDeath = 0;
        public int HungryToDeath
        {
            get => _hungryToDeath;
            set
            {
                _hungryToDeath = value;
                Debug.Log("饥饿过度计数: " + _hungryToDeath);
                if (_hungryToDeath >= 3)
                {
                    Debug.Log("玩家因饥饿过度死亡");
                    EventsManager.Instance.EventTrigger(Constants.PlayerDeadEvent);
                }
            }
        }
        
        private bool _isDying = false;
        
        private int _playerHungry = MaxPlayerHungry - 8;

        public int PlayerHungry
        {
            get => _playerHungry;
            set
            {
                if (value>0)
                {
                    _playerHungry = Mathf.Min(value,MaxPlayerHungry);
                    _isDying = false;
                }
                else
                {
                    _playerHungry = 0;
                    _isDying = true;
                }
                EventsManager.Instance.EventTrigger(Constants.HungryUIRefreshEvent);
            }
        }
        
        public const int MaxPlayerHungry = 20;
        
        private int _playerHealth = MaxPlayerHealth;

        public int PlayerHealth
        {
            get => _playerHealth;
            set
            {
                if (value > 0)
                {
                    _playerHealth = Mathf.Min(value,MaxPlayerHealth);
                    Debug.Log("玩家生命值变更为: " + _playerHealth);
                    EventsManager.Instance.EventTrigger(Constants.HealthUIRefreshEvent);
                }
                else
                {
                    _playerHealth = 0;
                    Debug.Log("玩家生命值变更为: " + _playerHealth);
                    EventsManager.Instance.EventTrigger(Constants.HealthUIRefreshEvent);
                    Debug.Log("玩家生命值为0死亡");
                    EventsManager.Instance.EventTrigger(Constants.PlayerDeadEvent);
                }
            }
        }
        public const int MaxPlayerHealth = 10;
        
        public int PlayerHappy = 10;
        
        private int _playerMoney = 200;
        public int PlayerMoney {
            get => _playerMoney;
            set
            {
                _playerMoney = value;
                Debug.Log("玩家金钱变更为: " + _playerMoney);
                EventsManager.Instance.EventTrigger(Constants.MoneyUIRefreshEvent);
            }
        }

        public List<FoodItem> ShoppingCartItems = new ();
        
        public List<DiscountItem> PlayerDiscountItems = new();
        public List<DiscountItem> UsingDiscountItems = new();

        public List<FoodItem> PlayerAteItems = new();

        protected override void Awake()
        {
            base.Awake();
            EventsManager.Instance.AddEventsListener(Constants.PlayerDeadEvent,OnGameOver);
            EventsManager.Instance.AddEventsListener(Constants.GameEndEvent,OnGameOver);
        }

        private void Start()
        {
            MusicManager.Instance.PlayBGM("Audio/GameBGM");
        }

        public void OnGameOver()
        {
            var allAchievements = FinalCheck.CheckFinal();
            // TODO
            EventsManager.Instance.EventTrigger<int>(Constants.DayEndEvent, DayCount);
        }
        
        public void BackMainScreen()
        {
            mainGameCanvas.gameObject.SetActive(false);
            dialogueRunner.gameObject.SetActive(false);
        }

        public void GameLaunch()
        {
            dialogueRunner.gameObject.SetActive(true);
            dialogueRunner.StartDialogue("StoryStart");
        }

        [YarnCommand("DisplayMainScene")]
        public static void DisplayMainScene()
        {
            GameManager.Instance.dialogueRunner.gameObject.SetActive(false);
            GameManager.Instance.mainGameCanvas.gameObject.SetActive(true);
            GameManager.Instance.StartGame();
        }

        public void StartGame()
        {
            //开始游戏时会+1天
            DayCount = 0;
            PlayerHealth = MaxPlayerHealth;
            PlayerHungry = MaxPlayerHungry;
            PlayerHappy = 0;
            PlayerMoney = 200;
            ShoppingCartItems.Clear();
            PlayerDiscountItems.Clear();
            UsingDiscountItems.Clear();
            PlayerAteItems.Clear();

            _isDying = false;
            _hungryToDeath = 0;

            haveFreeCouponThisDay = true;
            haveExchangeTimeThisDay = true;
            gachaTimesThisDay = 0;
            todayFighting = false;
            todayStolen = false;
            
            StartDay();
        }

        private void OnPlayerEat(List<FoodItem> foodItems)
        {
            if (todayFighting)
            {
                EverydayEvent.ShowEvent();
                return;
            }

            if (todayStolen)
            {
                return;
            }
            
            foreach (var foodItem in foodItems)
            {
                var item = new FoodItem(foodItem);
                
                PlayerHungry += item.Hungry;
                if (PlayerHungry > MaxPlayerHungry)
                {
                    PlayerHungry = MaxPlayerHungry;
                }
                
                PlayerHealth += item.Health;
                if (PlayerHealth > MaxPlayerHealth)
                {
                    PlayerHealth = MaxPlayerHealth;
                }
                
                PlayerAteItems.Add(item);
            }
        }

        public void StartDay()
        {
            DayCount += 1;
            EventsManager.Instance.EventTrigger<int>(Constants.DayStartEvent, DayCount);
            haveFreeCouponThisDay = true;
            haveExchangeTimeThisDay = true;
            gachaTimesThisDay = 0;

            todayFighting = false;
            todayStolen = false;
            
            //获得今日事件
            var today = EverydayEvent.GetEverydayEvent();
            if (today == DailyEvent.Fighting)
            {
                todayFighting = true;
            }

            if (today == DailyEvent.Stole)
            {
                todayStolen = true;
            }
        }

        public void EndDay()
        {
            Instance.PlayerHungry -= 10;
            
            EventsManager.Instance.EventTrigger<int>(Constants.DayEndEvent, DayCount);

            if (DayCount == 14)
            {
                EventsManager.Instance.EventTrigger(Constants.GameEndEvent);
            }
            
            // 清空购物车和使用的优惠券
            ShoppingCartItems.Clear();
            UsingDiscountItems.Clear();

            if (_isDying)
            {
                HungryToDeath++;
                PlayerHealth -= 3;
            }
            
            // 去下一天
            StartDay();
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