using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowFinal : MonoBehaviour
{
    public List<Sprite> result = new List<Sprite>();
    public GameObject Content;
    
    public void ShowFinalType(bool win, List<Achievement> achievements = null)
    {
        var img = GetComponent<Image>();
        if (win)
        {
            img.sprite = result[0];
        }
        else
        {
            img.sprite = result[1];
        }

        if (achievements != null)
        {
            foreach (var item in achievements)
            {
                var achi = Resources.Load<GameObject>("Prefab/Achieves");
                achi = GameObject.Instantiate(achi, Content.transform);
                var tittle = achi.transform.Find("标题").GetComponent<TextMeshProUGUI>();
                var des = achi.transform.Find("介绍").GetComponent<TextMeshProUGUI>();
                tittle.text = item.AchievementName;
                des.text = item.AchievementDescription;
            }
        }
        gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
