using System;
using System.Collections.Generic;
using Architecture;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// 控制手机页面切换
    /// </summary>
    public class PhoneController : MonoBehaviour
    {
        [SerializeField] private GameObject inShopPage;
        [SerializeField] private GameObject outShopPage;
        [SerializeField] private GameObject payPage;
        [SerializeField] private GameObject superCouponPage;
        [SerializeField] private GameObject myPage;
        
        [SerializeField] private GameObject freeCouponPagePrefab;

        private void OnEnable()
        {
            EventsManager.Instance.AddEventsListener<ShopperItem>(Constants.ShopClickedEvent, OpenInShopPage);
            EventsManager.Instance.AddEventsListener(Constants.FreeCouponEvent, ShowFreeCouponPage);
        }
        
        private void OnDisable()
        {
            EventsManager.Instance.RemoveListener<ShopperItem>(Constants.ShopClickedEvent, OpenInShopPage);
            EventsManager.Instance.RemoveListener(Constants.FreeCouponEvent, ShowFreeCouponPage);
        }
        
        private void ShowFreeCouponPage()
        {
            Debug.Log("尝试显示免费优惠券页面");
            if (GameManager.Instance.haveFreeCouponThisDay)
            {
                GameManager.Instance.haveFreeCouponThisDay = false;
                Instantiate(freeCouponPagePrefab, transform);
            }
            else
            {
                Debug.Log("今天已经领取过免费优惠券了");
                ShowDialog.Instance.ShowDialogInfo("今天已经领取过免费优惠券了");
            }
        }

        public void OpenInShopPage(ShopperItem item)
        {
            inShopPage.SetActive(true);
            outShopPage.SetActive(false);
            payPage.SetActive(false);
            superCouponPage.SetActive(false);
            myPage.SetActive(false);

            var foods = new List<FoodItem>();
            foreach (var foodItem in item.GetFoodItems())
            {
                foods.Add(new FoodItem(foodItem));
            }
            
            var inShopController = inShopPage.GetComponent<InShopController>();
            inShopController.SetShopInfo(item.GetShopIcon(),item.Name,item.ShopDescription,item.GetFoodItems());
        }
        
        public void OpenOutShopPage()
        {
            inShopPage.SetActive(false);
            outShopPage.SetActive(true);
            payPage.SetActive(false);
            superCouponPage.SetActive(false);
            myPage.SetActive(false);
        }
        
        public void OpenPayPage()
        {
            inShopPage.SetActive(false);
            outShopPage.SetActive(false);
            payPage.SetActive(true);
            superCouponPage.SetActive(false);
            myPage.SetActive(false);
        }
        
        public void OpenSuperCouponPage()
        {
            inShopPage.SetActive(false);
            outShopPage.SetActive(false);
            payPage.SetActive(false);
            superCouponPage.SetActive(true);
            myPage.SetActive(false);
        }
        
        public void OpenMyPage()
        {
            inShopPage.SetActive(false);
            outShopPage.SetActive(false);
            payPage.SetActive(false);
            superCouponPage.SetActive(false);
            myPage.SetActive(true);
        }
    }
}