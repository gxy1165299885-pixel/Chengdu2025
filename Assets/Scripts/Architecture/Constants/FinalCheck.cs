using System.Collections.Generic;
using System.Linq;
using Architecture;
using Unity.VisualScripting;
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
            achi.AchievementDescription = "吃了十顿窝窝头";
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
        /*破产吃货*/
        if (GameManager.Instance.PlayerMoney <= 0 && GameManager.Instance.DayCount > 14)
        {
            var achi = new Achievement();
            achi.AchievementName = "破产吃货";
            achi.AchievementDescription = "钱没了，但肚子是满的。";
            Achievements.Add(achi);
        }

        int counter = 0;
        int flag = 0;
        foreach (var day in PlatformItems.foodCounts)
        {
            int daySpend = 0;
            for (int i = 0; i < day; i++)
            {
                counter++;
                if (counter < l.Count)
                {
                    daySpend += l[counter].FoodPrice;
                }
            }
            if (daySpend <= 10)
            {
                flag++;
            }
        }
        /*生存大师*/        
        if (flag >= 3) // 连续3天，每天餐费不超过10元
        {
            var achi = new Achievement();
            achi.AchievementName = "生存大师";
            achi.AchievementDescription = "3天餐费不超过10元";
            Achievements.Add(achi);
        }

        counter = 0;
        flag = 0;
        foreach (var day in PlatformItems.foodCounts)
        {
            int daySpend = 0;
            for (int i = 0; i < day; i++)
            {
                counter++;
                if (counter < l.Count)
                {
                    daySpend += l[counter].FoodPrice;
                }
            }
            if (daySpend >= 100)
            {
                flag++;
            }
        }
        /*挥金如土*/
        if (flag > 0) // 单笔订单消费满100元
        {
            var achi = new Achievement();
            achi.AchievementName = "挥金如土";
            achi.AchievementDescription = "一顿饭吃掉半周预算，真正的土豪。";
            Achievements.Add(achi);
        }

        /*价格刺客受害者*/
        if ((from item in l select item.FoodName.Contains("自来水")).Any()) // 购买过"长白山天然自来水"
        {
            var achi = new Achievement();
            achi.AchievementName = "价格刺客受害者";
            achi.AchievementDescription = "为什么要在外卖点自来水？";
            Achievements.Add(achi);
        }
        
        /*满减战神*/
        if (PlatformItems.baipiao) // 单笔订单使用优惠券后实际支付0元
        {
            var achi = new Achievement();
            achi.AchievementName = "满减战神";
            achi.AchievementDescription = "白嫖的快乐，你值得拥有。";
            Achievements.Add(achi);
        }

        counter = 0;
        flag = 0;
        foreach (var day in PlatformItems.foodCounts)
        {
            int daySpend = 0;
            for (int i = 0; i < day; i++)
            {
                counter++;
                if (counter < l.Count)
                {
                    daySpend += l[counter].Health;
                }
            }
            if (daySpend <= -10)
            {
                flag++;
            }
        }
        /*辣不怕*/
        if (flag >0) // 一天内累计健康值因进食降低超过10点
        {
            var achi = new Achievement();
            achi.AchievementName = "辣不怕";
            achi.AchievementDescription = "一天健康快速降低。";
            Achievements.Add(achi);
        }
        

        /*菊花残*/
        if ((from item in l select item.FoodName.Contains("泻")).Any()) // 因健康值过低而使用"止泻药"
        {
            var achi = new Achievement();
            achi.AchievementName = "菊花残";
            achi.AchievementDescription = "使用过止泻药。";
            Achievements.Add(achi);
        }
        
        count= 
            (from item in l 
            where item.FoodShopName == "哥哥家的鸡公煲"
            select item.FoodName).Distinct().Count();
        /*鸡公煲专家*/
        if (count > 4) // 品尝过"哥哥家的鸡公煲"所有口味的鸡公煲
        {
            var achi = new Achievement();
            achi.AchievementName = "鸡公煲专家";
            achi.AchievementDescription = "从香辣到黄金，你是真正的鸡公煲品鉴师。";
            Achievements.Add(achi);
        }

        count= 
            (from item in l 
                where 
                    item.FoodName.Contains("炸") || 
                    item.FoodName.Contains("酥") ||
                    item.FoodName.Contains("薯条")
                select item.FoodName
                ).Distinct().Count();
        /*油炸爱好者*/
        if (count > 3) // 品尝过所有带"炸"、"酥"、"薯条"关键词的菜品
        {
            var achi = new Achievement();
            achi.AchievementName = "油炸爱好者";
            achi.AchievementDescription = "热量是什么？好吃就完事了。";
            Achievements.Add(achi);
        }
        
        count= 
            (from item in l 
                where item.FoodShopName.Contains("沙县")
                select item.FoodPrice
            ).Sum();
        /*沙县VIP*/
        if (count >= 100) // 在"沙县国际大酒店"消费满5次
        {
            var achi = new Achievement();
            achi.AchievementName = "沙县VIP";
            achi.AchievementDescription = "沙县国际大酒店消费满100元";
            Achievements.Add(achi);
        }

        count= 
            (from item in l 
                where 
                    item.FoodShopName.Contains("雪")
                select item.FoodName
            ).Distinct().Count();
        /*甜蜜负担*/
        if (count > 4) // 品尝过"冰雪蜜城甜蜜蜜"的所有饮品
        {
            var achi = new Achievement();
            achi.AchievementName = "甜蜜负担";
            achi.AchievementDescription = "糖分超标，但快乐满分。";
            Achievements.Add(achi);
        }
        count= 
            (from item in l 
                where 
                    item.FoodShopName.Contains("粥")
                select item.FoodName
            ).Distinct().Count();

        /*粥道中人*/
        if (count > 3) // 品尝过"养生粥铺"的所有粥品
        {
            var achi = new Achievement();
            achi.AchievementName = "粥道中人";
            achi.AchievementDescription = "养生之道，在于喝粥。";
            Achievements.Add(achi);
        }
        count= 
            (
                from item in l 
                select item.FoodName
            ).Distinct().Count();
        /*美食家*/
        if (true) // 品尝过50种不同的菜品
        {
            var achi = new Achievement();
            achi.AchievementName = "美食家";
            achi.AchievementDescription = "尝遍百味，方知人生。";
            Achievements.Add(achi);
        }

        var li =
        (
            from item in l
            group item.FoodShopName by item.FoodShopName
            into g
            select g.Count()
        ).ToList();
        flag = 0;
        foreach (var g in li)
        {
            if (g >= 5)
            {
                flag++;
            }
        }
        /*专一*/
        if (flag > 1) // 连续5天都在同一家店铺点餐
        {
            var achi = new Achievement();
            achi.AchievementName = "专一";
            achi.AchievementDescription = "忠诚的味蕾，不变的选择。";
            Achievements.Add(achi);
        }

        count= 
        (
            from item in l 
            where !item.FoodShopName.Contains("药")
            select item.FoodShopName
        ).Distinct().Count();
        /*雨露均沾*/
        if (count >= 14) // 在14天内光顾过所有出现的店铺（每家至少一次）
        {
            var achi = new Achievement();
            achi.AchievementName = "雨露均沾";
            achi.AchievementDescription = "公平对待每一家餐厅。";
            Achievements.Add(achi);
        }


        var jcount = 0;
        foreach (var item in PlatformItems.discountsCount)
        {
            jcount+=item;
        }
        /*极限生存*/
        if (jcount <=0 && GameManager.Instance.DayCount > 14) // 不使用任何优惠券，仅用200元成功存活14天
        {
            var achi = new Achievement();
            achi.AchievementName = "极限生存";
            achi.AchievementDescription = "真正的生存挑战，不使用任何外力。";
            Achievements.Add(achi);
        }
        

        count = (from item in l where item.FoodName.Contains("泻药") select item).Count();
        /*健康模范*/
        if (GameManager.Instance.PlayerHealth >= 10 && count<=0) // 通关时健康值保持在100%且从未使用止泻药
        {
            var achi = new Achievement();
            achi.AchievementName = "健康模范";
            achi.AchievementDescription = "完美的饮食管理，健康的典范。";
            Achievements.Add(achi);
        }

        
        count = (from item in l where item.FoodShopName.Contains("烤翅") select item.FoodName).Distinct().Count();
        /*烤翅达人*/
        if (count > 3) // 品尝过"疯狂烤翅"的所有口味
        {
            var achi = new Achievement();
            achi.AchievementName = "烤翅达人";
            achi.AchievementDescription = "从变态辣到蜂蜜芥末，你是烤翅的狂热粉丝。";
            Achievements.Add(achi);
        }

        count = (from item in l where item.FoodShopName.Contains("火锅冒菜") select item.FoodName).Distinct().Count();
        /*火锅勇士*/
        if (count >= 3) // 同一天内吃过3种以上"川渝火锅冒菜"的菜品
        {
            var achi = new Achievement();
            achi.AchievementName = "火锅勇士";
            achi.AchievementDescription = "一个人也能吃出火锅的气势。";
            Achievements.Add(achi);
        }

        foreach (var achi in Achievements)
        {
            Debug.Log(achi.AchievementName);
        }
        return Achievements;
    }
}

public class Achievement
{
    public string AchievementName;
    public string AchievementDescription;
}
