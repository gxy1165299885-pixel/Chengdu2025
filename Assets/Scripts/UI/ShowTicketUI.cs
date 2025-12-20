using System;
using System.Collections;
using System.Linq;
using Architecture;
using TMPro;
using UnityEngine;

public class ShowTicketUI : MonoBehaviour
{
    private TextMeshProUGUI day;
    private TextMeshProUGUI cost;
    private TextMeshProUGUI ticket;
    private TextMeshProUGUI save;
    private TextMeshProUGUI spend;
    private TextMeshProUGUI remain;
    private void OnEnable()
    {
        day = transform.Find("下单时间").GetComponent<TextMeshProUGUI>();
        cost = transform.Find("原金额").GetComponent<TextMeshProUGUI>();
        ticket = transform.Find("神卷使用张数").GetComponent<TextMeshProUGUI>();
        save = transform.Find("神卷减免金额").GetComponent<TextMeshProUGUI>();
        spend = transform.Find("实际支付").GetComponent<TextMeshProUGUI>();
        remain = transform.Find("剩余资金").GetComponent<TextMeshProUGUI>();
        day.text = $"第{GameManager.Instance.dayCount}天";
        
        var total = (from food in PlatformItems.BuyFoods select food.FoodPrice).Sum();
        cost.text = $"{total}";
        ticket.text = $"{PlatformItems.Discounts}";
        save.text = $"{total - PlatformItems.spendd}";
        spend.text = $"{PlatformItems.spendd}";
        remain.text = $"{GameManager.Instance.PlayerMoney}";
        StartCoroutine(ShowTicket());
    }

    IEnumerator ShowTicket()
    {
        yield return new WaitForSeconds(0f);
    }
}
