using System;
using Architecture;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    /// <summary>
    /// 幸运神券
    /// </summary>
    public class GetRandomCouponButton : MonoBehaviour,IPointerClickHandler
    {
        [SerializeField] public TextMeshProUGUI priceText;
        [SerializeField] public TextMeshProUGUI insuranceInfoText;
        
        private int _nextPrice = 0;
        private int _haveGachaTimes = 0;
        
        private int[] GachaPrices = new []{1,2,4,7,10,15,20,25,30};

        // 抽卡卡池：通过在数组中重复不同模板来实现不同稀有度（常见的满减券多、特殊券少）
        private DiscountItem[] gachaPool = new DiscountItem[]
        {
            // 常见：小额立减（无门槛）
            new DiscountItem(){ discountType = DiscountType.sub, discountValue = 1, startToUse = 0 },
            new DiscountItem(){ discountType = DiscountType.sub, discountValue = 1, startToUse = 0 },
            new DiscountItem(){ discountType = DiscountType.sub, discountValue = 1, startToUse = 0 },
            new DiscountItem(){ discountType = DiscountType.sub, discountValue = 1, startToUse = 0 },
            new DiscountItem(){ discountType = DiscountType.sub, discountValue = 1, startToUse = 0 },
            new DiscountItem(){ discountType = DiscountType.sub, discountValue = 1, startToUse = 0 },
            new DiscountItem(){ discountType = DiscountType.sub, discountValue = 2, startToUse = 0 },
            new DiscountItem(){ discountType = DiscountType.sub, discountValue = 2, startToUse = 0 },
            new DiscountItem(){ discountType = DiscountType.sub, discountValue = 2, startToUse = 0 },
            new DiscountItem(){ discountType = DiscountType.sub, discountValue = 2, startToUse = 0 },
            new DiscountItem(){ discountType = DiscountType.sub, discountValue = 3, startToUse = 0 },
            new DiscountItem(){ discountType = DiscountType.sub, discountValue = 3, startToUse = 0 },
            new DiscountItem(){ discountType = DiscountType.sub, discountValue = 3, startToUse = 0 },

            // 常见：满减券（低门槛）
            new DiscountItem(){ discountType = DiscountType.sub, discountValue = 5, startToUse = 8 },
            new DiscountItem(){ discountType = DiscountType.sub, discountValue = 5, startToUse = 10 },
            new DiscountItem(){ discountType = DiscountType.sub, discountValue = 5, startToUse = 10 },
            new DiscountItem(){ discountType = DiscountType.sub, discountValue = 5, startToUse = 15 },
            new DiscountItem(){ discountType = DiscountType.sub, discountValue = 5, startToUse = 15 },
            new DiscountItem(){ discountType = DiscountType.sub, discountValue = 5, startToUse = 15 },
            new DiscountItem(){ discountType = DiscountType.sub, discountValue = 5, startToUse = 15 },
            new DiscountItem(){ discountType = DiscountType.sub, discountValue = 7, startToUse = 15 },

            // 不太常见：中额满减
            new DiscountItem(){ discountType = DiscountType.sub, discountValue = 10, startToUse = 20 },
            new DiscountItem(){ discountType = DiscountType.sub, discountValue = 12, startToUse = 25 },

            // 稀有：高额满减
            new DiscountItem(){ discountType = DiscountType.sub, discountValue = 20, startToUse = 40 },

            // 特殊券（无门槛），概率较低：换餐券、免单券、嘉豪券、十二折券
            new DiscountItem(){ discountType = DiscountType.change, discountValue = 0, startToUse = 0 },
            new DiscountItem(){ discountType = DiscountType.change, discountValue = 0, startToUse = 0 },
            new DiscountItem(){ discountType = DiscountType.free, discountValue = 0, startToUse = 0 },
            new DiscountItem(){ discountType = DiscountType.free, discountValue = 0, startToUse = 0 },
            new DiscountItem(){ discountType = DiscountType.Jiahao, discountValue = 0, startToUse = 0 },
            new DiscountItem(){ discountType = DiscountType.shier, discountValue = 0, startToUse = 0 },
        };

        private void OnEnable()
        {
            EventsManager.Instance.AddEventsListener<int>(Constants.DayStartEvent,RefreshGachaTimes);
            RefreshNextPrice();
        }

        private void OnDisable()
        {
            EventsManager.Instance.RemoveListener<int>(Constants.DayStartEvent,RefreshGachaTimes);
        }

        private void RefreshGachaTimes(int _)
        {
            _haveGachaTimes = 0;
        }
        
        private void RefreshNextPrice()
        {
            _nextPrice = GachaPrices[Mathf.Min(_haveGachaTimes, GachaPrices.Length - 1)];
            priceText.text = "下一次的价格是 "+_nextPrice+" ¥";
            insuranceInfoText.text = _haveGachaTimes <= 4
                ? "您已经抽过 " + _haveGachaTimes + " 次优惠券了，第五次必出特殊券哦！（仅限一次）"
                : "您已经抽过 " + _haveGachaTimes + " 次优惠券了，祝您好运！";
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (GameManager.Instance.PlayerMoney < _nextPrice)
            {
                ShowDialog.Instance.ShowDialogInfo("余额不足，下次再来吧！");
                return;
            }
            else
            {
                GameManager.Instance.PlayerMoney -= _nextPrice;
                var get = GetRandomDiscountItem();
                GameManager.Instance.PlayerDiscountItems.Add(get);
                ShowDialog.Instance.ShowDialogInfo("幸运获得:  " + get.GetDisplayName() + " !");
                _haveGachaTimes++;
                RefreshNextPrice();
            }
        }
        
        private DiscountItem GetRandomDiscountItem()
        {
            if (_haveGachaTimes == 4)
            {
                // 第五次抽卡，必出特殊券
                var specialCoupons = Array.FindAll(gachaPool, item =>
                    item.discountType == DiscountType.change ||
                    item.discountType == DiscountType.free ||
                    item.discountType == DiscountType.Jiahao ||
                    item.discountType == DiscountType.shier);
                var template = specialCoupons[UnityEngine.Random.Range(0, specialCoupons.Length)];
                return new DiscountItem()
                {
                    discountType = template.discountType,
                    discountValue = template.discountValue,
                    startToUse = template.startToUse,
                    isBomb = template.isBomb,
                    expireTime = template.expireTime,
                };
            }
            else
            {
                var template = gachaPool[UnityEngine.Random.Range(0, gachaPool.Length)];
                return new DiscountItem()
                {
                    discountType = template.discountType,
                    discountValue = template.discountValue,
                    startToUse = template.startToUse,
                    isBomb = template.isBomb,
                    expireTime = template.expireTime,
                };
            }
        }
    }
}