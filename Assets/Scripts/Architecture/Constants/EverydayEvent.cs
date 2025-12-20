using Architecture;
using UnityEngine;

public enum DailyEvent
{
    None,//无事件
    Fighting,//骑士决斗
    QQ,//企鹅自动续费
    EarnMoney,//捡到40块钱
    SleepLate,//起晚了,加10元配送费
    Stole,//外卖被偷走了
    Platform,//平台大战
}
public class EverydayEvent
{
    public static DailyEvent day;
    private static int counter = Random.Range(2, 4);
    public static DailyEvent GetEverydayEvent()
    {
        day = DailyEvent.None;
        if (counter <= 0)
        {
            day = (DailyEvent)Random.Range(1, 7);
            counter = Random.Range(2, 4);
        }
        counter--;
        if (day == DailyEvent.QQ)
        {
            GameManager.Instance.PlayerMoney -= 38;
        }
        if (day == DailyEvent.EarnMoney)
        {
            GameManager.Instance.PlayerMoney += 40;
        }
        ShowEvent();
        return day;
    }

    public static void ShowEvent()
    {
        if (day == DailyEvent.None)
        {
            return;
        }
        Debug.Log(day);
    }
}
