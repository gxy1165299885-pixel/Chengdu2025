using Architecture;
using TMPro;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class InitDiscount : MonoBehaviour
{
    public GameObject useContent;
    void OnEnable()
    {
        UpdateDiscount();
        UpdateUseDiscount();
    }

    public void UpdateDiscount()
    {
        for (int i = gameObject.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }
        if (GameManager.Instance.PlayerDiscountItems.Count == 0)
        {
            Debug.Log("你还没有卷");
            return;
        }
        for(int i=0;i<GameManager.Instance.PlayerDiscountItems.Count;i++)
        {
            var obj = Resources.Load<GameObject>("Prefab/券");
            obj = Instantiate(obj,gameObject.transform);
            var o = GameManager.Instance.PlayerDiscountItems[i];
            //obj.GetComponent<DiscountDisplay>().SetDiscountInfo(ref o);
            var btn = obj.transform.Find("使用神券按钮").GetComponent<Button>();
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(()=>OnUse(o));
        }
    }

    public void UpdateUseDiscount()
    {
        for (int i = useContent.gameObject.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(useContent.gameObject.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < GameManager.Instance.UsingDiscountItems.Count; i++)
        {
            var obj = Resources.Load<GameObject>("Prefab/展示卷");
            obj = Instantiate(obj,useContent.gameObject.transform);
            var btn = obj.GetComponent<Button>();
            var txt = obj.GetComponentInChildren<TextMeshProUGUI>();
            txt.text = GameManager.Instance.UsingDiscountItems[i].GetDisplayName();
            btn.onClick.RemoveAllListeners();
            var o = GameManager.Instance.UsingDiscountItems[i];
            btn.onClick.AddListener(()=>OnReturn(o));
        }
    }


    public void OnUse(DiscountItem info)
    {
        GameManager.Instance.PlayerDiscountItems.Remove(info);
        GameManager.Instance.UsingDiscountItems.Add(info);
        UpdateDiscount();
        UpdateUseDiscount();
    }
    
    public void OnReturn(DiscountItem info)
    {
        GameManager.Instance.PlayerDiscountItems.Add(info);
        GameManager.Instance.UsingDiscountItems.Remove(info);
        UpdateDiscount();
        UpdateUseDiscount();
    }
}
