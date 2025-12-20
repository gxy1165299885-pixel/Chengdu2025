using System;
using System.Collections;
using System.Linq;
using Architecture;
using TMPro;
using UnityEngine;

public class ShowTicketUI : MonoBehaviour
{
    
    [SerializeField]private TextMeshProUGUI day;
    [SerializeField]private TextMeshProUGUI cost;
    [SerializeField]private TextMeshProUGUI ticket;
    [SerializeField]private TextMeshProUGUI save;
    [SerializeField]private TextMeshProUGUI spend;
    [SerializeField]private TextMeshProUGUI remain;
    public GameObject Content;
    private void OnEnable()
    {
        /*day = transform.Find("下单时间").GetComponent<TextMeshProUGUI>();
        cost = transform.Find("原金额").GetComponent<TextMeshProUGUI>();
        ticket = transform.Find("神卷使用张数").GetComponent<TextMeshProUGUI>();
        save = transform.Find("神卷减免金额").GetComponent<TextMeshProUGUI>();
        spend = transform.Find("实际支付").GetComponent<TextMeshProUGUI>();
        remain = transform.Find("剩余资金").GetComponent<TextMeshProUGUI>();*/
        day.text = $"第{GameManager.Instance.DayCount}天";
        var total = (from food in PlatformItems.BuyFoods select food.FoodPrice).Sum();
        cost.text = $"{total}";
        ticket.text = $"{PlatformItems.Discounts}";
        save.text = $"{total - PlatformItems.spendd}";
        spend.text = $"{PlatformItems.spendd}";
        remain.text = $"{GameManager.Instance.PlayerMoney}";
        for (int i = Content.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(Content.transform.GetChild(i).gameObject);
        }
        foreach (var food in PlatformItems.BuyFoods)
        {
            var order = Resources.Load<GameObject>("Prefab/Order");
            order = Instantiate(order, Content.transform);
            var fname = order.transform.Find("FoodName").GetComponent<TextMeshProUGUI>();
            fname.text = food.FoodName;
            var fprice = order.transform.Find("Price").GetComponent<TextMeshProUGUI>();
            fprice.text = $"{food.FoodPrice}";
        }
        StartCoroutine(ShowTicket());
    }

    IEnumerator ShowTicket()
    {
        yield return new WaitForSeconds(0f);
    }

    public void QuitTicket()
    {
        Destroy(gameObject);
    }
}
