using System;
using System.Collections.Generic;
using Architecture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FreshNewDiscount : MonoBehaviour
{
    public GameObject buttons;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        ShowDiscount();
    }

    public void ShowDiscount()
    {
        var l = GetRandomDiscount();
        for (int i = 0; i < 3; i++)
        {
            if (i < l.Count)
            {
                var obj = buttons.transform.GetChild(i).gameObject;
                obj.SetActive(true);
                var item = l[i];
                var txt = obj.GetComponentInChildren<TextMeshProUGUI>();
                var btn = obj.GetComponentInChildren<Button>();
                txt.text = item.GetDisplayName()+"\n"+item.GetDescription();
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(()=>OnClick(item));
            }
            else
            {
                buttons.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public List<DiscountItem> GetRandomDiscount()
    {
        List<DiscountItem> list = new List<DiscountItem>();
        var ix = Random.Range(0, 1f);
        if (ix < 0.3f)
        {
            var special = Random.Range(1, 5);
            var newItem = new DiscountItem
            {
                discountType = (DiscountType)(special),
                discountValue = 0,
                expireTime = 15,
                isBomb = false,
                startToUse = 0
            };
            list.Add(newItem);
            if (newItem.discountType is DiscountType.shier)
            {
                return list;
            }
        }
        for (int i = list.Count; i < 3; i++)
        {
            var newItem = new DiscountItem
            {
                discountType = DiscountType.sub,
                discountValue = Random.Range(1,5)*5,
                startToUse = Random.Range(0,5)*5,
                expireTime = 15,
                isBomb = false,
            };
            list.Add(newItem);
        }
        return list;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(DiscountItem item)
    {
        var iname = item.GetDisplayName();
        iname = iname.Replace("\n", "");
        ShowDialog.Instance.ShowDialogInfo($"你领取了{iname}");
        if (item.discountType == DiscountType.shier)
        {
            GameManager.Instance.UsingDiscountItems.Add(item);
        }
        else
        {
            GameManager.Instance.PlayerDiscountItems.Add(item);
        }
        gameObject.SetActive(false);
    }
}
