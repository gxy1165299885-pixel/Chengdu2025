using Architecture;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class FreeCouponButton : MonoBehaviour,IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("免费优惠券按钮被点击");
            EventsManager.Instance.EventTrigger(Constants.FreeCouponEvent);
        }
    }
}