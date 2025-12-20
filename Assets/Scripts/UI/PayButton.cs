using Architecture;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// 支付按钮
    /// </summary>
    public class PayButton : MonoBehaviour
    {
        public void OnPayButtonClicked()
        {
            if (PlatformItems.BuyFood(GameManager.Instance.ShoppingCartItems,
                    GameManager.Instance.UsingDiscountItems) == -1)
            {
                // TODO: 提示余额不足
            }
        }
    }
}