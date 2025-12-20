using System;
using Architecture;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// 玩家角色的状态显示
    /// </summary>
    public class PlayerDisplayController : MonoBehaviour
    {
        [SerializeField] private Image healthBar;

        private void OnEnable()
        {
            EventsManager.Instance.AddEventsListener(Constants.HealthUIRefreshEvent, SetHealthBar);
        }
        
        private void OnDisable()
        {
            EventsManager.Instance.RemoveListener(Constants.HealthUIRefreshEvent, SetHealthBar);
        }

        private void SetHealthBar()
        {
            healthBar.fillAmount = (float)GameManager.Instance.PlayerHealth/GameManager.MaxPlayerHealth;
        }
    }
}