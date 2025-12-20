using Architecture;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// 显示外卖店家
    /// </summary>
    public class ShopDisplayController : MonoBehaviour,IPointerClickHandler
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI shopName;
        [SerializeField] private RectTransform starsParent;
        [SerializeField] private GameObject starPrefab;
        [SerializeField] private GameObject emptyStarPrefab;

        private ShopperItem _shopRef;
        
        public void SetShopDisplay(Sprite shopIcon, string theName,ShopperItem shopRef)
        
        {
            Random.InitState(GameManager.Instance.dayCount+ theName.GetHashCode()); // 使用天数和店名的哈希值作为随机种子
            int rating = Random.Range(3,6); // 生成3到5的随机评分
            Random.InitState((int)System.DateTime.Now.Ticks); // 恢复随机种子
            icon.sprite = shopIcon;
            this.shopName.text = theName;
            _shopRef = shopRef;
            // 清空现有星星
            foreach (Transform child in starsParent)
            {
                Destroy(child.gameObject);
            }

            // 添加实心星星
            for (int i = 0; i < rating; i++)
            {
                Instantiate(starPrefab, starsParent);
            }

            // 添加空心星星
            for (int i = rating; i < 5; i++)
            {
                Instantiate(emptyStarPrefab, starsParent);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            EventsManager.Instance.EventTrigger<ShopperItem>(Constants.ShopClickedEvent,_shopRef);
        }
    }
}