using System;
using System.Collections.Generic;
using Architecture;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class PayController : MonoBehaviour
    {
        [SerializeField] private GameObject payDiscountPage;
        [SerializeField] private Transform discountItemsContainer;
        [SerializeField] private CouponController couponPrefab;
        public List<DiscountItem> useDiscountItems;

        private void OnEnable()
        {
            EventsManager.Instance.AddEventsListener<DiscountItem>(Constants.CouponUseClickedEvent, AddUseDiscount);
        }

        private void OnDisable()
        {
            EventsManager.Instance.RemoveListener<DiscountItem>(Constants.CouponUseClickedEvent, AddUseDiscount);
        }

        private void AddUseDiscount(DiscountItem discountItem)
        {
            useDiscountItems.Add(discountItem);
        }

        public void OpenPayDiscountPage()
        {
            payDiscountPage.SetActive(true);
            useDiscountItems.Clear();
            foreach (Transform t in discountItemsContainer)
            {
                Destroy(t.gameObject);
            }

            foreach (var discountHave in GameManager.Instance.PlayerDiscountItems)
            {
                Instantiate(couponPrefab,discountItemsContainer).SetCouponInfo(discountHave);
            }
        }
        
    }
}