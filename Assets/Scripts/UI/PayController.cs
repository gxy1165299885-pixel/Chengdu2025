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
        [SerializeField] private DiscountDisplay couponPrefab;
        public List<DiscountItem> useDiscountItems;

        private void OnEnable()
        {
            useDiscountItems.Clear();
            EventsManager.Instance.AddEventsListener<DiscountItem>(Constants.CouponUseClickedEvent, AddUseDiscount);
            OpenPayDiscountPage();
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
            useDiscountItems.Clear();
            foreach (Transform t in discountItemsContainer)
            {
                Destroy(t.gameObject);
            }

            for (int i = 0; i < GameManager.Instance.PlayerDiscountItems.Count; i++)
            {
                var discountHave = GameManager.Instance.PlayerDiscountItems[i];
                Instantiate(couponPrefab,discountItemsContainer).SetDiscountInfo(ref discountHave);
            }
        }
        
    }
}