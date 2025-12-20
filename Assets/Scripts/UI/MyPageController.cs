using Architecture;
using UnityEngine;

namespace UI
{
    public class MyPageController : MonoBehaviour
    {
        [SerializeField] private Transform contentTransform;
        [SerializeField] private GameObject discountDisplayPrefab;
        
        private void OnEnable()
        {
            RefreshDiscounts();
        }
        
        private void RefreshDiscounts()
        {
            // 清空现有显示
            foreach (Transform child in contentTransform)
            {
                Destroy(child.gameObject);
            }

            // 获取玩家的优惠券列表
            var discounts = GameManager.Instance.PlayerDiscountItems;

            // 创建新的显示
            for (int i=0; i < discounts.Count; i++)
            {
                var discount = discounts[i];
                var displayObj = Instantiate(discountDisplayPrefab, contentTransform);
                var displayComponent = displayObj.GetComponent<DiscountDisplay>();
                displayComponent.SetDiscountInfo(ref discount);
                displayComponent.HideUseButton();
            }
        }
    }
}