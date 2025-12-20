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
        [SerializeField] private TextMeshProUGUI hungryText;
        [SerializeField] private TextMeshProUGUI moneyText;

        private void OnEnable()
        {
            EventsManager.Instance.AddEventsListener(Constants.HungryUIRefreshEvent, SetHungryText);
            EventsManager.Instance.AddEventsListener(Constants.MoneyUIRefreshEvent,SetMoneyText);
        }
        
        private void OnDisable()
        {
            EventsManager.Instance.RemoveListener(Constants.HungryUIRefreshEvent, SetHungryText);
            EventsManager.Instance.RemoveListener(Constants.MoneyUIRefreshEvent,SetMoneyText);
        }

        private void SetHungryText()
        {
            hungryText.text = GameManager.Instance.PlayerHungry + "/" + GameManager.MaxPlayerHungry;
        }
        
        private void SetMoneyText()
        {
            moneyText.text = $"{GameManager.Instance.PlayerMoney:F2}¥";
        }
    }
}