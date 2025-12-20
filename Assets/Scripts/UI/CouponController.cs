using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class CouponController : MonoBehaviour,IPointerClickHandler
    {
        private DiscountItem _discountItem;
        
        public void SetCouponInfo(DiscountItem discountItem)
        {
            _discountItem = new DiscountItem
            {
                discountType = discountItem.discountType,
                discountValue = discountItem.discountValue,
                isBomb = discountItem.isBomb,
                startToUse = discountItem.startToUse
            };

            // TODO Set coupon information display logic here
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            
        }
    }
}