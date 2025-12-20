using System.Collections.Generic;
using System.Linq;
using Architecture;
using UnityEngine;

public class FinalCheck
{
    public static List<Achievement> CheckFinal()
    {
        var l = GameManager.Instance.PlayerAteItems;
        var Achievements = new List<Achievement>();
        var count = 0;
        /*应该花费的金额*/
        var spend = (from foods in l select foods.FoodPrice).Sum();
        /*实际花费的金额*/
        var cost = 200 - GameManager.Instance.PlayerMoney;
        /*省下的金额*/
        var save = spend - cost;
        /*米饭仙人*/
        count = (from foods in l where foods.FoodName == "白米饭" select foods).Count();
        if (count >= 10)
        {
            var achi = new Achievement();
            achi.AchievementName = "米饭仙人";
            achi.AchievementDescription = "吃了十顿白米饭";
            Achievements.Add(achi);
        }
        /*窝窝头仙人*/
        count = (from foods in l where foods.FoodName == "窝窝头" select foods).Count();
        if (count >= 10)
        {
            var achi = new Achievement();
            achi.AchievementName = "窝窝头仙人";
            achi.AchievementDescription = "吃了十顿白米饭";
            Achievements.Add(achi);
        }
        /*省钱达人*/
        if (GameManager.Instance.PlayerMoney >= 100)
        {
            var achi = new Achievement();
            achi.AchievementName = "省钱达人";
            achi.AchievementDescription = "剩余金额大于100";
            Achievements.Add(achi);
        }
        /*戒戒你好*/
        if (GameManager.Instance.DayCount < 14)
        {
            var achi = new Achievement();
            achi.AchievementName = "戒戒你好";
            achi.AchievementDescription = "没能活过14天";
            Achievements.Add(achi);
        }
        /*极限*/
        if (GameManager.Instance.PlayerMoney <= 52)
        {
            var achi = new Achievement();
            achi.AchievementName = "极限";
            achi.AchievementDescription = "剩余的金额小于52";
            Achievements.Add(achi);
        }
        /*身体是革命的本钱*/
        if (GameManager.Instance.PlayerMoney >= 2 && GameManager.Instance.DayCount < 14)
        {
            var achi = new Achievement();
            achi.AchievementName = "身体是革命的本钱";
            achi.AchievementDescription = "因为不健康的饮食导致死亡";
            Achievements.Add(achi);
        }
        return Achievements;
    }
}

public class Achievement
{
    public string AchievementName;
    public string AchievementDescription;
}
