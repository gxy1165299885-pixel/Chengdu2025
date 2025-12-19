using System;
using System.Collections.Generic;
using Architecture;
using UnityEngine;

namespace UI
{
    public class PhoneController : MonoBehaviour
    {
        [SerializeField] private GameObject inShopPage;
        [SerializeField] private GameObject outShopPage;
        [SerializeField] private GameObject superCouponPage;
        [SerializeField] private GameObject myPage;

        private void Awake()
        {
            EventsManager.Instance.AddEventsListener<ShopperItem>(Constants.ShopClickedEvent, OpenInShopPage);
        }

        public void OpenInShopPage(ShopperItem item)
        {
            inShopPage.SetActive(true);
            outShopPage.SetActive(false);
            superCouponPage.SetActive(false);
            myPage.SetActive(false);

            if (item == null)
            {
                return;
            }

            var foods = new List<FoodItem>();
            foreach (var foodItem in item.GetFoodItems())
            {
                foods.Add(new FoodItem(foodItem));
            }
            
            // TODO 更新InShopPage的显示内容
            var inShopController = inShopPage.GetComponent<InShopController>();
            inShopController.SetShopInfo(item.GetShopIcon(),item.Name,item.ShopDescription,item.GetFoodItems());
        }
        
        public void OpenOutShopPage()
        {
            inShopPage.SetActive(false);
            outShopPage.SetActive(true);
            superCouponPage.SetActive(false);
            myPage.SetActive(false);
        }
        
        public void OpenSuperCouponPage()
        {
            inShopPage.SetActive(false);
            outShopPage.SetActive(false);
            superCouponPage.SetActive(true);
            myPage.SetActive(false);
        }
        
        public void OpenMyPage()
        {
            inShopPage.SetActive(false);
            outShopPage.SetActive(false);
            superCouponPage.SetActive(false);
            myPage.SetActive(true);
        }
    }
}