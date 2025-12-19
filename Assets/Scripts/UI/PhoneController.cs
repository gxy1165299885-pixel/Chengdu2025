using UnityEngine;

namespace UI
{
    public class PhoneController : MonoBehaviour
    {
        [SerializeField] private GameObject inShopPage;
        [SerializeField] private GameObject outShopPage;
        [SerializeField] private GameObject superCouponPage;
        [SerializeField] private GameObject myPage;
        
        public void OpenInShopPage()
        {
            inShopPage.SetActive(true);
            outShopPage.SetActive(false);
            superCouponPage.SetActive(false);
            myPage.SetActive(false);
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