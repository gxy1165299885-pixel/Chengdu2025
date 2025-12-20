using Architecture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowDialog : SingletonBase<ShowDialog>
{
    public static GameObject phone;
    public void ShowDialogInfo(string info,Sprite sprite = null)
    {
        if (phone == null)
        {
            phone = GameObject.Find("手机画面");
        }

        if (phone == null)
        {
            return;
        }
        var dialog = Resources.Load<GameObject>("Prefab/Dialog");
        dialog = GameObject.Instantiate(dialog,phone.transform);
        var txt = dialog.GetComponentInChildren<TextMeshProUGUI>();
        var img = dialog.transform.GetChild(0).GetComponent<Image>();
        txt.text = info;
        if (sprite != null)
        {
            img.sprite = sprite;
            img.rectTransform.sizeDelta = (sprite.rect.size/sprite.spriteAtlasTextureScale)*100;
            img.gameObject.SetActive(true);
        }
        else
        {
            img.gameObject.SetActive(false);
        }
        
    }
}
