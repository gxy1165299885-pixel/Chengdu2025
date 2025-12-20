using System;
using Architecture;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
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