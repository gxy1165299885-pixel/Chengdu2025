using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// 挂在优惠券上
    /// </summary>
    public class DiscountDisplay : MonoBehaviour
    {
        [SerializeField] private RectTransform highlightRectTransform;
        [SerializeField] private TextMeshProUGUI discountNameText;
        [SerializeField] private TextMeshProUGUI discountDescriptionText;
        [SerializeField] private TextMeshProUGUI discountValueText;
        [SerializeField] private TextMeshProUGUI discountExpiryText;
        [SerializeField] private TextMeshProUGUI hasBeenBombedText;
        [SerializeField] private Button bombButton;

        public void SetHighlightActive(bool isActive)
        {
            highlightRectTransform.gameObject.SetActive(isActive);
        }
        
        public void SetDiscountInfo(ref DiscountItem discountItem)
        {
            discountNameText.text = discountItem.discountType.ToString();
            discountDescriptionText.text = discountItem.startToUse+"起用";
            discountValueText.text = $"折扣值: {discountItem.discountValue * 100}%";
            //discountExpiryText.text = $"有效期至: {discountItem.expiryDate.ToShortDateString()}";
            hasBeenBombedText.gameObject.SetActive(discountItem.isBomb);
            bombButton.gameObject.SetActive(!discountItem.isBomb);
            bombButton.onClick.RemoveAllListeners();
            // 点击膨胀按钮后，将优惠券标记为已膨胀
        }
        
        
    }
}
