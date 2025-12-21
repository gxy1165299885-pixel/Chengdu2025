using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Architecture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowFinal : MonoBehaviour
{
    public List<Sprite> result = new List<Sprite>();
    public GameObject Content;

    public bool win;
    public List<Achievement> achievements;

    public void ShowFinalType(bool win, List<Achievement> achievements = null)
    {
        gameObject.SetActive(true);
        StartCoroutine(Show(win, achievements));
    }

    IEnumerator Show(bool win, List<Achievement> achievements = null)
    {
        yield return null;
        var img = GetComponentInChildren<Image>();
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

        transform.GetChild(0).Find("结余").GetComponent<TextMeshProUGUI>().text = $"结余:{GameManager.Instance.PlayerMoney}元";
        transform.GetChild(0).Find("使用券数").GetComponent<TextMeshProUGUI>().text = $"使用{(from item in PlatformItems.discountsCount select item).Sum()}张券";
        transform.GetChild(0).Find("存活天数").GetComponent<TextMeshProUGUI>().text = $"存活{GameManager.Instance.DayCount}天";
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
