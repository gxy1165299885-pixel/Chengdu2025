using System;
using Architecture;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// 挂在店外页面上，负责显示所有店铺信息
    /// </summary>
    public class OutShopController : MonoBehaviour
    {
        [SerializeField] private GameObject shopInformationPrefab;
        [SerializeField] private Transform shopInformationContainer;

        private void OnEnable()
        {
            foreach (Transform info in shopInformationContainer)
            {
                Destroy(info.gameObject);
            }
            
            foreach (var shop in PlatformItems.ShopperItems)
            {
                var shopInfo = Instantiate(shopInformationPrefab, shopInformationContainer);
                shopInfo.GetComponent<ShopDisplayController>().SetShopDisplay(
                    ResourceManager.Instance.Load<Sprite>(shop.ShopIconName),
                    shop.Name, shop);
            }
        }
    }
}