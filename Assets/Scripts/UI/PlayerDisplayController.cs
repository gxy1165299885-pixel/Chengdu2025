using System;
using Architecture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// 玩家角色的状态显示
    /// </summary>
    public class PlayerDisplayController : MonoBehaviour
    {
        [SerializeField] private Image hungryBar;
        [SerializeField] private TextMeshProUGUI moneyText;

        private void OnEnable()
        {
            EventsManager.Instance.AddEventsListener(Constants.HungryUIRefreshEvent, SetHungryBar);
            EventsManager.Instance.AddEventsListener(Constants.MoneyUIRefreshEvent,SetMoneyText);
        }
        
        private void OnDisable()
        {
            EventsManager.Instance.RemoveListener(Constants.HungryUIRefreshEvent, SetHungryBar);
            EventsManager.Instance.RemoveListener(Constants.MoneyUIRefreshEvent,SetMoneyText);
        }

        private void SetHungryBar()
        {
            hungryBar.fillAmount = (float)GameManager.Instance.PlayerHungry/GameManager.MaxPlayerHungry;
        }
        
        private void SetMoneyText()
        {
            moneyText.text = $"{GameManager.Instance.PlayerMoney:F2}¥";
        }
    }
}