using System;
using Architecture;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerDisplayController : MonoBehaviour
    {
        [SerializeField] private Image healthBar;

        private void Awake()
        {
            EventsManager.Instance.AddEventsListener(Constants.UIRefreshEvent, () =>
            {
                SetHealthBar((float)GameManager.Instance.PlayerHealth/GameManager.MaxPlayerHealth);
            });
        }

        private void SetHealthBar(float value)
        {
            healthBar.fillAmount = value;
        }
    }
}