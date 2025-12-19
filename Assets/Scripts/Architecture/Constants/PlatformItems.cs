using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Architecture;
using GamePlay;
using Random = UnityEngine.Random;

public class PlatformItems
{
    public static List<ShopperItem> ShopperItems = new List<ShopperItem>()
    {
        new ShopperItem()
        {
            Name = "哥哥家的鸡公煲",
            ShopDescription = "",
            ShopIconName = "",
        },
        new ShopperItem()
        {
            Name = "开封菜炸鸡",
            ShopDescription = "",
            ShopIconName = "",
        },
        new ShopperItem()
        {
            Name = "被炒饭耽误的炒面馆",
            ShopDescription = "",
            ShopIconName = "",
        },
        new ShopperItem()
        {
            Name = "0糖0脂0能量轻食",
            ShopDescription = "",
            ShopIconName = "",
        },
        new ShopperItem()
        {
            Name = "有一家药店",
            ShopDescription = "",
            ShopIconName = "",
        }
    };
    public static List<FoodItem> FoodItems = new List<FoodItem>()
    {
        new FoodItem()
        {
            FoodShopName = "哥哥家的鸡公煲",
            FoodDescription = "",
            FoodIconName = "",
            FoodName = "香辣鸡公煲",
            FoodPrice = 18,
            Hungry = 10,
            Health = -2
        },
        new FoodItem()
        {
            FoodShopName = "哥哥家的鸡公煲",
            FoodDescription = "",
            FoodIconName = "",
            FoodName = "鲍汁鸡公煲",
            FoodPrice = 28,
            Hungry = 10,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "哥哥家的鸡公煲",
            FoodDescription = "",
            FoodIconName = "",
            FoodName = "超级豪华鸡公煲",
            FoodPrice = 38,
            Hungry = 10,
            Health = 1
        },
        new FoodItem()
        {
            FoodShopName = "哥哥家的鸡公煲",
            FoodDescription = "",
            FoodIconName = "",
            FoodName = "黄金鸡公煲",
            FoodPrice = 48,
            Hungry = 10,
            Health = 2
        },
        new FoodItem()
        {
            FoodShopName = "开封菜炸鸡",
            FoodDescription = "",
            FoodIconName = "",
            FoodName = "老北京鸡肉卷",
            FoodPrice = 10,
            Hungry = 5,
            Health = -2
        },
        new FoodItem()
        {
            FoodShopName = "开封菜炸鸡",
            FoodDescription = "",
            FoodIconName = "",
            FoodName = "香辣鸡腿堡",
            FoodPrice = 12,
            Hungry = 8,
            Health = -2
        },
        new FoodItem()
        {
            FoodShopName = "开封菜炸鸡",
            FoodDescription = "",
            FoodIconName = "",
            FoodName = "蜜汁烤鸡",
            FoodPrice = 15,
            Hungry = 12,
            Health = -2
        },
        new FoodItem()
        {
            FoodShopName = "开封菜炸鸡",
            FoodDescription = "",
            FoodIconName = "",
            FoodName = "香酥炸鸡",
            FoodPrice = 20,
            Hungry = 12,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "开封菜炸鸡",
            FoodDescription = "",
            FoodIconName = "",
            FoodName = "薯条",
            FoodPrice = 5,
            Hungry = 2,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "开封菜炸鸡",
            FoodDescription = "",
            FoodIconName = "",
            FoodName = "黄金SPA鸡腿堡",
            FoodPrice = 25,
            Hungry = 12,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "被炒饭耽误的炒面馆",
            FoodDescription = "",
            FoodIconName = "",
            FoodName = "白米饭",
            FoodPrice = 2,
            Hungry = 10,
            Health = -1
        },
        new FoodItem()
        {
            FoodShopName = "被炒饭耽误的炒面馆",
            FoodDescription = "",
            FoodIconName = "",
            FoodName = "窝窝头",
            FoodPrice = 2,
            Hungry = 10,
            Health = -1
        },
        new FoodItem()
        {
            FoodShopName = "被炒饭耽误的炒面馆",
            FoodDescription = "",
            FoodIconName = "",
            FoodName = "蛋炒饭",
            FoodPrice = 8,
            Hungry = 10,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "被炒饭耽误的炒面馆",
            FoodDescription = "",
            FoodIconName = "",
            FoodName = "蛋炒面",
            FoodPrice = 8,
            Hungry = 10,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "被炒饭耽误的炒面馆",
            FoodDescription = "",
            FoodIconName = "",
            FoodName = "蛋炒面加火腿",
            FoodPrice = 10,
            Hungry = 10,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "被炒饭耽误的炒面馆",
            FoodDescription = "",
            FoodIconName = "",
            FoodName = "蛋炒饭加火腿",
            FoodPrice = 10,
            Hungry = 10,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "0糖0脂0能量轻食",
            FoodDescription = "",
            FoodIconName = "",
            FoodName = "蔓越莓三明治",
            FoodPrice = 18,
            Hungry = 3,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "0糖0脂0能量轻食",
            FoodDescription = "",
            FoodIconName = "",
            FoodName = "长白山天然自来水",
            FoodPrice = 10,
            Hungry = 0,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "0糖0脂0能量轻食",
            FoodDescription = "",
            FoodIconName = "",
            FoodName = "鸡胸肉三明治",
            FoodPrice = 22,
            Hungry = 5,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "有一家药店",
            FoodDescription = "",
            FoodIconName = "",
            FoodName = "止泻药",
            FoodPrice = 30,
            Hungry = 0,
            Health = 10
        },
    };

    //public static List<FoodItem> Buyed = new List<FoodItem>();\
    /// <summary>
    /// 购买购物车中的食物
    /// </summary>
    /// <param name="food">购物车中的食物</param>
    /// <param name="items">使用的卷</param>
    /// <returns>本次消费的总额，-1为余额不足</returns>
    public static int BuyFood(List<FoodItem> food,List<DiscountItem> items = null)
    {
        var money = GameManager.Instance.PlayerMoney;
        var spend = 0;
        foreach (var foodItem in food)
        {
            spend = foodItem.FoodPrice;
        }
        if (items != null)
        {
            foreach (var item in items)
            {
                if (spend < item.startToUse)
                {
                    continue;
                }
                switch (item.discountType)
                {
                    case DiscountType.sub: spend -= item.discountValue;break;
                    case DiscountType.change: food[Random.Range(0,food.Count)] = FoodItems[Random.Range(0, FoodItems.Count - 1)]; break;
                    case DiscountType.free: spend -= food[Random.Range(0,food.Count)].FoodPrice;break;
                    case DiscountType.Jiahao:spend = (int)(spend*Random.Range(0.8f, 1.2f)); break;
                }
            }
        }
        spend = Mathf.Max(0, spend);
        if (money >= spend)
        {
            money -= spend;
            GameManager.Instance.PlayerMoney = money;
            EventsManager.Instance.EventTrigger("PlayerEatEvent",food);
            //Buyed.Add(food);
            return spend;
        }
        else
        {
            return -1;
        }
    }
    
}

public class DiscountItem//:ICoupon
{
    //卷的类型
    public DiscountType discountType;
    //折扣值，满减时为金额，折扣时为折扣率
    public int discountValue;
    //起用点，只有在达到这个价格时才可以用卷
    public int startToUse;
    //卷是否已经膨胀过
    public bool isBomb;
}
/// <summary>
/// 商铺数据
/// </summary>
public class ShopperItem
{
    //商铺名
    public string Name;
    //商铺的图标名
    public string ShopIconName;
    //商铺的描述
    public string ShopDescription;
}

public static class ShopperItemExtensions
{
    public static Sprite GetShopIcon(this ShopperItem shopperItem)
    {
        if (shopperItem.ShopIconName == "")
        {
            return Resources.Load<Sprite>(shopperItem.Name);
        }
        else
        {
            return Resources.Load<Sprite>(shopperItem.ShopIconName);
        }
    }

    public static List<FoodItem> GetFoodItems(this ShopperItem shopperItem)
    {
        var foods = 
            (
                from food in PlatformItems.FoodItems
                where food.FoodShopName == shopperItem.Name
                select food
            ).ToList();
        return foods;
    }
}

/// <summary>
/// 外卖数据
/// </summary>
public class FoodItem
{
    //食物的名称
    public string FoodName;
    //售卖该食物的商家
    public string FoodShopName;
    //食物描述
    public string FoodDescription;
    //食物图标名
    public string FoodIconName;
    //食物参考价格
    public int FoodPrice;
    //增加饱食度
    public int Hungry;
    //增加健康值
    public int Health;
}

public static class FoodItemExtensions
{
    /// <summary>
    /// 获取食物的展示图标
    /// </summary>
    /// <returns>食物的展示图标</returns>
    public static Sprite GetFoodIcon(this FoodItem foodItem)
    {
        if (foodItem.FoodIconName == "")
        {
            return Resources.Load<Sprite>(foodItem.FoodName);
        }
        else
        {
            return Resources.Load<Sprite>(foodItem.FoodIconName);
        }
    }

    /// <summary>
    /// 获取食物的所属商铺
    /// </summary>
    /// <returns>食物所属的商铺</returns>
    public static ShopperItem GetShopItem(this ShopperItem shopperItem)
    {
        var i = 
            from shop in PlatformItems.ShopperItems 
            where shop.Name == shopperItem.Name
            select shop;
        return i.FirstOrDefault();
    }
}

[Flags]
public enum DiscountType
{
    sub = 1 << 0,//满减卷
    //discount = 1 << 1,//折扣卷
    change = 1 << 2,//换餐卷
    free = 1 << 3,//免单卷
    Jiahao = 1 << 4,//嘉豪卷，随机修改花费值
} 