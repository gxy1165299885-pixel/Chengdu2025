using System;
using System.Collections.Generic;
using Architecture;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = System.Random;

namespace UI
{
    public class CouponExchangeButton : MonoBehaviour,IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("优惠券兑换按钮被点击");
            if (GameManager.Instance.haveExchangeTimeThisDay)
            {
                if (GameManager.Instance.PlayerDiscountItems.Count < 3)
                {
                    Debug.Log("优惠券太少");
                    ShowDialog.Instance.ShowDialogInfo("优惠券不足，无法兑换！");
                }
                else
                {
                    // 随机移除3张优惠券
                    RemoveRandomKInPlace(GameManager.Instance.PlayerDiscountItems, 3);
                    // 增加一张随机优惠券
                    var newCoupon = GetRandomDiscountItem();
                    if (newCoupon.discountType == DiscountType.shier)
                    {
                        GameManager.Instance.UsingDiscountItems.Add(newCoupon);
                    }
                    else
                    {
                        GameManager.Instance.PlayerDiscountItems.Add(newCoupon);
                    }
                    Debug.Log("成功兑换到优惠券: " + newCoupon.GetDisplayName());
                    ShowDialog.Instance.ShowDialogInfo("失去3张券，成功兑换到新优惠券: " + newCoupon.GetDisplayName());
                    GameManager.Instance.haveExchangeTimeThisDay = false;
                }
            }
            else
            {
                ShowDialog.Instance.ShowDialogInfo("今天已经兑换过优惠券了!");
            }
        }

        private DiscountItem GetRandomDiscountItem()
        {
            return new DiscountItem()
            {
                discountType =  (DiscountType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(DiscountType)).Length),
            };
        }

        private void RemoveRandomKInPlace<T>(List<T> list, int k, Random rng = null)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (k <= 0) return;
            rng ??= new Random();
            int removeCount = Math.Min(k, list.Count);

            var indices = new HashSet<int>();
            while (indices.Count < removeCount)
                indices.Add(rng.Next(list.Count));

            // 按降序删除，避免索引位移问题
            var idxList = new List<int>(indices);
            idxList.Sort((a, b) => b.CompareTo(a));
            foreach (var idx in idxList)
                list.RemoveAt(idx);
        }
    }
}