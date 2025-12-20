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
                Debug.Log("余额不足！");
                ShowDialog.Instance.ShowDialogInfo("余额不足！");
            }
            else
            {
                if (GameManager.Instance.todayStolen)
                {
                    GameManager.Instance.ShoppingCartItems.Clear();
                    GameManager.Instance.UsingDiscountItems.Clear();
                    GameManager.Instance.todayStolen = false;
                    EverydayEvent.ShowEvent();
                    return;
                }
                GameManager.Instance.EndDay();
            }
        }
    }
}