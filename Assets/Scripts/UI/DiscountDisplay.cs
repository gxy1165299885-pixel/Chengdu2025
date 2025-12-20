using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// 挂在优惠券上，可以复用（背包内的可膨胀）
    /// </summary>
    public class DiscountDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI discountNameText;
        [SerializeField] private TextMeshProUGUI discountDescriptionText;
        [SerializeField] private TextMeshProUGUI discountExpiryText;
        
        public void SetDiscountInfo(ref DiscountItem discountItem)
        {
            discountNameText.text = discountItem.GetDisplayName().Replace('\n',' ');
            discountDescriptionText.text = discountItem.GetDescription();
            discountExpiryText.text = $"有效期至: 第{discountItem.expireTime}天";
        }
        
        public void HideUseButton()
        {
            var btn = transform.Find("使用神券按钮")?.GetComponent<Button>();
            if (btn != null)
            {
                btn.gameObject.SetActive(false);
            }
        }
    }
}
