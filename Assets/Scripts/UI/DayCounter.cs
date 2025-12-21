using System;
using Architecture;
using UnityEngine;

namespace UI
{
    public class DayCounter : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI dayText;
        private void Awake()
        {
            EventsManager.Instance.AddEventsListener(Constants.DayChangedEvent,RefreshDayText);
        }
        private void RefreshDayText()
        {
            dayText.text = GameManager.Instance.DayCount.ToString();
        }
    }
}