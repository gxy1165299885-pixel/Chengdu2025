using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Architecture;
//using GamePlay;
using Random = UnityEngine.Random;

public class PlatformItems
{
    public static List<ShopperItem> ShopperItems = new List<ShopperItem>()
    {
        new ShopperItem()
        {
            Name = "哥哥家的鸡公煲",
            ShopDescription = "老板说他真的是哥哥，但我们都觉得他像叔叔。鸡肉很嫩，就像老板的脾气一样火爆。",
            ShopIconName = "Icon/哥哥家的鸡公煲",
        },
        new ShopperItem()
        {
            Name = "开封菜炸鸡",
            ShopDescription = "源自河南开封的神秘菜系，主打一个‘炸’字。吃了可能会上火，但不吃会伤心。",
            ShopIconName = "Icon/开封菜炸鸡",
        },
        new ShopperItem()
        {
            Name = "被炒饭耽误的炒面馆",
            ShopDescription = "老板原本想做炒饭之神，结果炒面意外走红。现在他每天都在怀疑人生中颠勺。",
            ShopIconName = "Icon/炒面",
        },
        new ShopperItem()
        {
            Name = "0糖0脂0能量轻食",
            ShopDescription = "吃完感觉像没吃一样，非常适合修仙人士。除了贵和饿，没有任何缺点。",
            ShopIconName = "Icon/0",
        },
        new ShopperItem()
        {
            Name = "有一家药店",
            ShopDescription = "虽然是药店，但偶尔也卖点养生茶。店员眼神犀利，一眼就能看出你昨晚熬到了几点。",
            ShopIconName = "Icon/药店",
        },
        // 新增店铺
        new ShopperItem()
        {
            Name = "川渝火锅冒菜",
            ShopDescription = "微辣是最后的妥协，中辣是尊严的底线，特辣是通往肛肠科的门票。",
            ShopIconName = "Icon/四川火锅",
        },
        new ShopperItem()
        {
            Name = "冰雪蜜城甜蜜蜜",
            ShopDescription = "你爱我，我爱你，老板说他不赚钱，全靠大家捧场。便宜到让你怀疑人生。",
            ShopIconName = "Icon/蜜雪",
        },
        new ShopperItem()
        {
            Name = "沙县国际大酒店",
            ShopDescription = "全球连锁，品质保证。在这里，你能用最少的钱，吃出最国际化的孤独感。",
            ShopIconName = "Icon/沙县",
        },
        new ShopperItem()
        {
            Name = "深夜烧烤摊",
            ShopDescription = "白天不营业，晚上不睡觉。烟火气里藏着老板的江湖故事，和你的卡路里。",
            ShopIconName = "Icon/深夜烧烤",
        },
        new ShopperItem()
        {
            Name = "东北饺子馆",
            ShopDescription = "好吃不过饺子，好玩不过...咳咳。老板娘热情得让你想喊妈，分量大得让你想打包。",
            ShopIconName = "Icon/东北饺子",
        },
        new ShopperItem()
        {
            Name = "正宗兰州拉面",
            ShopDescription = "牛肉薄如蝉翼，刀工堪比外科医生。汤头鲜美，面条劲道，就是肉少了点。",
            ShopIconName = "Icon/兰州",
        },
        new ShopperItem()
        {
            Name = "快乐汉堡王",
            ShopDescription = "每一口都是热量的狂欢，每一层都是脂肪的馈赠。吃完这顿，明天再减肥吧。",
            ShopIconName = "Icon/汉堡王",
        },
        new ShopperItem()
        {
            Name = "老妈蹄花汤",
            ShopDescription = "胶原蛋白的源泉，美容养颜的神器。喝一口，感觉皮肤都变好了（心理作用）。",
            ShopIconName = "Icon/老妈蹄花",
        },
        new ShopperItem()
        {
            Name = "疯狂烤翅",
            ShopDescription = "变态辣挑战赛常驻举办地。吃完记得备好牛奶和救护车。",
            ShopIconName = "Icon/疯狂烤翅",
        },
        new ShopperItem()
        {
            Name = "养生粥铺",
            ShopDescription = "熬夜党的最后避风港。喝了这碗粥，假装昨晚早睡了。",
            ShopIconName = "Icon/养生粥铺",
        }
    };
    public static List<FoodItem> FoodItems = new List<FoodItem>()
    {
        new FoodItem()
        {
            FoodShopName = "哥哥家的鸡公煲",
            FoodDescription = "辣度适中，鸡肉紧实。吃完感觉能去参加选秀节目出道。",
            FoodIconName = "Icon/dish",
            FoodName = "香辣鸡公煲",
            FoodPrice = 18,
            Hungry = 10,
            Health = -2
        },
        new FoodItem()
        {
            FoodShopName = "哥哥家的鸡公煲",
            FoodDescription = "浓郁的鲍汁包裹着每一块鸡肉，虽然没有鲍鱼，但有鲍鱼的梦想。",
            FoodIconName = "Icon/dish",
            FoodName = "鲍汁鸡公煲",
            FoodPrice = 28,
            Hungry = 10,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "哥哥家的鸡公煲",
            FoodDescription = "加了午餐肉、丸子、豆皮...豪华到让你忘记这只是一锅鸡。",
            FoodIconName = "Icon/dish",
            FoodName = "超级豪华鸡公煲",
            FoodPrice = 38,
            Hungry = 10,
            Health = 1
        },
        new FoodItem()
        {
            FoodShopName = "哥哥家的鸡公煲",
            FoodDescription = "传说中用了金箔（其实是蛋黄酱），每一口都是人民币的味道。",
            FoodIconName = "Icon/dish",
            FoodName = "黄金鸡公煲",
            FoodPrice = 48,
            Hungry = 10,
            Health = 2
        },
        new FoodItem()
        {
            FoodShopName = "开封菜炸鸡",
            FoodDescription = "虽然叫老北京，但跟北京没啥关系。就像老婆饼里没有老婆一样。",
            FoodIconName = "Icon/dish",
            FoodName = "老北京鸡肉卷",
            FoodPrice = 10,
            Hungry = 5,
            Health = -2
        },
        new FoodItem()
        {
            FoodShopName = "开封菜炸鸡",
            FoodDescription = "经典的辣味，经典的拉肚子。痛并快乐着的最佳选择。",
            FoodIconName = "Icon/dish",
            FoodName = "香辣鸡腿堡",
            FoodPrice = 12,
            Hungry = 8,
            Health = -2
        },
        new FoodItem()
        {
            FoodShopName = "开封菜炸鸡",
            FoodDescription = "甜甜的蜜汁，适合不想吃辣又想吃肉的宝宝。吃完记得擦嘴。",
            FoodIconName = "Icon/dish",
            FoodName = "蜜汁烤鸡",
            FoodPrice = 15,
            Hungry = 12,
            Health = -2
        },
        new FoodItem()
        {
            FoodShopName = "开封菜炸鸡",
            FoodDescription = "外酥里嫩，一口下去全是油。减肥路上的绊脚石，快乐源泉。",
            FoodIconName = "Icon/dish",
            FoodName = "香酥炸鸡",
            FoodPrice = 20,
            Hungry = 12,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "开封菜炸鸡",
            FoodDescription = "土豆的尸体，油炸的灵魂。搭配番茄酱，是西方美食的巅峰。",
            FoodIconName = "Icon/dish",
            FoodName = "薯条",
            FoodPrice = 5,
            Hungry = 2,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "开封菜炸鸡",
            FoodDescription = "给鸡腿做过按摩，肉质松软。吃起来像是在和鸡腿谈恋爱。",
            FoodIconName = "Icon/dish",
            FoodName = "黄金SPA鸡腿堡",
            FoodPrice = 25,
            Hungry = 12,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "被炒饭耽误的炒面馆",
            FoodDescription = "纯洁无瑕的碳水化合物。没有任何配菜的干扰，直击灵魂的饱腹感。",
            FoodIconName = "Icon/dish",
            FoodName = "白米饭",
            FoodPrice = 2,
            Hungry = 10,
            Health = -1
        },
        new FoodItem()
        {
            FoodShopName = "被炒饭耽误的炒面馆",
            FoodDescription = "忆苦思甜必备。吃一口，感觉生活其实也没那么苦了。",
            FoodIconName = "Icon/dish",
            FoodName = "窝窝头",
            FoodPrice = 2,
            Hungry = 10,
            Health = -1
        },
        new FoodItem()
        {
            FoodShopName = "被炒饭耽误的炒面馆",
            FoodDescription = "隔夜饭的华丽转身。粒粒分明，油光发亮，是炒饭界的教科书。",
            FoodIconName = "Icon/dish",
            FoodName = "蛋炒饭",
            FoodPrice = 8,
            Hungry = 10,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "被炒饭耽误的炒面馆",
            FoodDescription = "老板的成名作。面条劲道，鸡蛋金黄，每一口都是对炒饭的背叛。",
            FoodIconName = "Icon/dish",
            FoodName = "蛋炒面",
            FoodPrice = 8,
            Hungry = 10,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "被炒饭耽误的炒面馆",
            FoodDescription = "加了火腿，身价倍增。这是炒面界的轻奢单品。",
            FoodIconName = "Icon/dish",
            FoodName = "蛋炒面加火腿",
            FoodPrice = 10,
            Hungry = 10,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "被炒饭耽误的炒面馆",
            FoodDescription = "火腿丁隐藏在米饭中，像是在玩捉迷藏。找到一个，快乐加倍。",
            FoodIconName = "Icon/dish",
            FoodName = "蛋炒饭加火腿",
            FoodPrice = 10,
            Hungry = 10,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "0糖0脂0能量轻食",
            FoodDescription = "酸酸甜甜，口感丰富。吃完感觉自己是个精致的都市丽人。",
            FoodIconName = "Icon/dish",
            FoodName = "蔓越莓三明治",
            FoodPrice = 18,
            Hungry = 3,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "0糖0脂0能量轻食",
            FoodDescription = "就是自来水，但是装在好看的瓶子里。智商税的完美体现。",
            FoodIconName = "Icon/dish",
            FoodName = "长白山天然自来水",
            FoodPrice = 10,
            Hungry = 0,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "0糖0脂0能量轻食",
            FoodDescription = "鸡胸肉柴得像木头，但为了身材，我忍。吃得苦中苦，方为人上人。",
            FoodIconName = "Icon/dish",
            FoodName = "鸡胸肉三明治",
            FoodPrice = 22,
            Hungry = 5,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "有一家药店",
            FoodDescription = "当你吃坏肚子时的救命稻草。比任何美食都更让你安心。",
            FoodIconName = "Icon/med",
            FoodName = "止泻药",
            FoodPrice = 30,
            Hungry = 0,
            Health = 10
        },
        // 新增菜品 - 川渝火锅冒菜
        new FoodItem()
        {
            FoodShopName = "川渝火锅冒菜",
            FoodDescription = "一个人的火锅。红油翻滚，辣味冲天，吃完记得喝牛奶。",
            FoodIconName = "Icon/dish",
            FoodName = "单人冒菜套餐",
            FoodPrice = 25,
            Hungry = 12,
            Health = -1
        },
        new FoodItem()
        {
            FoodShopName = "川渝火锅冒菜",
            FoodDescription = "鸭血嫩滑，粉丝吸满汤汁。每一口都是对味蕾的暴击。",
            FoodIconName = "Icon/dish",
            FoodName = "鸭血粉丝冒菜",
            FoodPrice = 22,
            Hungry = 10,
            Health = -1
        },
        new FoodItem()
        {
            FoodShopName = "川渝火锅冒菜",
            FoodDescription = "全是肉！全是肉！肉食动物的狂欢，减肥人士的噩梦。",
            FoodIconName = "Icon/dish",
            FoodName = "纯肉冒菜",
            FoodPrice = 35,
            Hungry = 15,
            Health = -2
        },
        new FoodItem()
        {
            FoodShopName = "川渝火锅冒菜",
            FoodDescription = "酥脆的肉片，撒上辣椒面。看剧神器，根本停不下来。",
            FoodIconName = "Icon/dish",
            FoodName = "现炸小酥肉",
            FoodPrice = 18,
            Hungry = 5,
            Health = -1
        },
        new FoodItem()
        {
            FoodShopName = "川渝火锅冒菜",
            FoodDescription = "解辣神器。当你被辣得怀疑人生时，它就是你的救世主。",
            FoodIconName = "Icon/dish",
            FoodName = "红糖冰粉",
            FoodPrice = 8,
            Hungry = 2,
            Health = 1
        },
        // 新增菜品 - 冰雪蜜城甜蜜蜜
        new FoodItem()
        {
            FoodShopName = "冰雪蜜城甜蜜蜜",
            FoodDescription = "只要几块钱，就能拥有快乐。虽然柠檬片薄得像纸，但心意是厚的。",
            FoodIconName = "Icon/dish",
            FoodName = "冰鲜柠檬水",
            FoodPrice = 4,
            Hungry = 1,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "冰雪蜜城甜蜜蜜",
            FoodDescription = "巨大的冰淇淋，巨大的满足。吃得慢了会化，吃得快了会头疼。",
            FoodIconName = "Icon/dish",
            FoodName = "摩天脆脆",
            FoodPrice = 3,
            Hungry = 2,
            Health = -1
        },
        new FoodItem()
        {
            FoodShopName = "冰雪蜜城甜蜜蜜",
            FoodDescription = "珍珠Q弹，奶茶香甜。虽然知道是粉冲的，但架不住它便宜啊。",
            FoodIconName = "Icon/dish",
            FoodName = "珍珠奶茶",
            FoodPrice = 7,
            Hungry = 3,
            Health = -1
        },
        new FoodItem()
        {
            FoodShopName = "冰雪蜜城甜蜜蜜",
            FoodDescription = "满满一杯全是料，喝完不用吃饭了。性价比之王。",
            FoodIconName = "Icon/dish",
            FoodName = "棒打鲜橙",
            FoodPrice = 8,
            Hungry = 2,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "冰雪蜜城甜蜜蜜",
            FoodDescription = "粉粉嫩嫩的，适合拍照。味道嘛，就是甜甜的恋爱味（工业糖精味）。",
            FoodIconName = "Icon/dish",
            FoodName = "草莓摇摇奶昔",
            FoodPrice = 9,
            Hungry = 3,
            Health = -1
        },
        // 新增菜品 - 沙县国际大酒店
        new FoodItem()
        {
            FoodShopName = "沙县国际大酒店",
            FoodDescription = "皮薄馅大，沾上花生酱，简直是人间美味。扁肉界的扛把子。",
            FoodIconName = "Icon/dish",
            FoodName = "飘香拌面",
            FoodPrice = 6,
            Hungry = 8,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "沙县国际大酒店",
            FoodDescription = "脆弹爽口，一口一个。汤清味鲜，适合宿醉后的清晨。",
            FoodIconName = "Icon/dish",
            FoodName = "脆皮扁肉",
            FoodPrice = 8,
            Hungry = 6,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "沙县国际大酒店",
            FoodDescription = "蒸出来的美味，保留了食材的原汁原味。虽然只有四个，但个个是精华。",
            FoodIconName = "Icon/dish",
            FoodName = "柳叶蒸饺",
            FoodPrice = 8,
            Hungry = 6,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "沙县国际大酒店",
            FoodDescription = "巨大的鸡腿，卤得入味。吃完感觉自己充满了力量，可以再去搬两块砖。",
            FoodIconName = "Icon/dish",
            FoodName = "卤鸡腿饭",
            FoodPrice = 15,
            Hungry = 12,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "沙县国际大酒店",
            FoodDescription = "滋补养生，虽然不知道是不是真的乌鸡，但喝起来心理安慰满分。",
            FoodIconName = "Icon/dish",
            FoodName = "天麻乌鸡汤",
            FoodPrice = 12,
            Hungry = 4,
            Health = 2
        },
        // 新增菜品 - 深夜烧烤摊
        new FoodItem()
        {
            FoodShopName = "深夜烧烤摊",
            FoodDescription = "肥瘦相间，滋滋冒油。撒上孜然辣椒，是深夜最罪恶的诱惑。",
            FoodIconName = "Icon/dish",
            FoodName = "羊肉串",
            FoodPrice = 5,
            Hungry = 2,
            Health = -1
        },
        new FoodItem()
        {
            FoodShopName = "深夜烧烤摊",
            FoodDescription = "外焦里嫩，软糯粘牙。烤过的鸡爪，比前任的手还好牵。",
            FoodIconName = "Icon/dish",
            FoodName = "烤鸡爪",
            FoodPrice = 6,
            Hungry = 2,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "深夜烧烤摊",
            FoodDescription = "蒜蓉是灵魂，茄子是载体。吃完嘴里有味，心里有光。",
            FoodIconName = "Icon/dish",
            FoodName = "烤茄子",
            FoodPrice = 12,
            Hungry = 5,
            Health = -1
        },
        new FoodItem()
        {
            FoodShopName = "深夜烧烤摊",
            FoodDescription = "韭菜壮阳？不知道真假，反正吃完牙缝里全是绿的。",
            FoodIconName = "Icon/dish",
            FoodName = "烤韭菜",
            FoodPrice = 8,
            Hungry = 3,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "深夜烧烤摊",
            FoodDescription = "馒头切片烤得酥脆，刷上酱料。比肉还香，真的。",
            FoodIconName = "Icon/dish",
            FoodName = "烤馒头片",
            FoodPrice = 3,
            Hungry = 5,
            Health = -1
        },
        // 新增菜品 - 东北饺子馆
        new FoodItem()
        {
            FoodShopName = "东北饺子馆",
            FoodDescription = "经典的搭配，清新的口感。就像东北人的性格，直爽不油腻。",
            FoodIconName = "Icon/dish",
            FoodName = "猪肉白菜水饺",
            FoodPrice = 18,
            Hungry = 12,
            Health = 1
        },
        new FoodItem()
        {
            FoodShopName = "东北饺子馆",
            FoodDescription = "韭菜的香气霸道地占据你的口腔。吃完请勿在密闭空间呼吸。",
            FoodIconName = "Icon/dish",
            FoodName = "韭菜鸡蛋水饺",
            FoodPrice = 16,
            Hungry = 10,
            Health = 1
        },
        new FoodItem()
        {
            FoodShopName = "东北饺子馆",
            FoodDescription = "酸菜是东北的灵魂。酸爽开胃，一口一个，根本停不下来。",
            FoodIconName = "Icon/dish",
            FoodName = "酸菜猪肉水饺",
            FoodPrice = 20,
            Hungry = 12,
            Health = 1
        },
        new FoodItem()
        {
            FoodShopName = "东北饺子馆",
            FoodDescription = "酸甜酥脆，肉量感人。东北菜的排面，不吃后悔。",
            FoodIconName = "Icon/dish",
            FoodName = "锅包肉",
            FoodPrice = 38,
            Hungry = 10,
            Health = -1
        },
        new FoodItem()
        {
            FoodShopName = "东北饺子馆",
            FoodDescription = "色彩斑斓，口感丰富。虽然叫大拉皮，但吃起来很优雅。",
            FoodIconName = "Icon/dish",
            FoodName = "东北大拉皮",
            FoodPrice = 18,
            Hungry = 6,
            Health = 0
        },
        // 新增菜品 - 正宗兰州拉面
        new FoodItem()
        {
            FoodShopName = "正宗兰州拉面",
            FoodDescription = "一清二白三红四绿五黄。这不仅仅是一碗面，这是一件艺术品。",
            FoodIconName = "Icon/dish",
            FoodName = "兰州牛肉面",
            FoodPrice = 15,
            Hungry = 10,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "正宗兰州拉面",
            FoodDescription = "面片劲道，汤汁浓郁。比拉面更有嚼劲，适合牙口好的同学。",
            FoodIconName = "Icon/dish",
            FoodName = "刀削面",
            FoodPrice = 16,
            Hungry = 10,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "正宗兰州拉面",
            FoodDescription = "没有汤水的干扰，面条更加爽滑。夏天吃它，爽翻天。",
            FoodIconName = "Icon/dish",
            FoodName = "凉面",
            FoodPrice = 12,
            Hungry = 8,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "正宗兰州拉面",
            FoodDescription = "加肉！加肉！只有肉才能抚慰我受伤的心灵。虽然只有几片，但很珍贵。",
            FoodIconName = "Icon/dish",
            FoodName = "加肉牛肉面",
            FoodPrice = 25,
            Hungry = 12,
            Health = 1
        },
        new FoodItem()
        {
            FoodShopName = "正宗兰州拉面",
            FoodDescription = "茶叶蛋的升级版。咸香入味，是拉面的最佳伴侣。",
            FoodIconName = "Icon/dish",
            FoodName = "卤蛋",
            FoodPrice = 2,
            Hungry = 1,
            Health = 0
        },
        // 新增菜品 - 快乐汉堡王
        new FoodItem()
        {
            FoodShopName = "快乐汉堡王",
            FoodDescription = "两层肉饼，双倍快乐。一口咬下去，汁水四溢，满嘴留香。",
            FoodIconName = "Icon/dish",
            FoodName = "双层皇堡",
            FoodPrice = 28,
            Hungry = 12,
            Health = -2
        },
        new FoodItem()
        {
            FoodShopName = "快乐汉堡王",
            FoodDescription = "虽然是鳕鱼，但也是油炸的。假装健康的选择。",
            FoodIconName = "Icon/dish",
            FoodName = "深海鳕鱼堡",
            FoodPrice = 22,
            Hungry = 10,
            Health = -1
        },
        new FoodItem()
        {
            FoodShopName = "快乐汉堡王",
            FoodDescription = "洋葱圈炸得酥脆，比薯条更有个性。吃完嘴里有洋葱味，慎点。",
            FoodIconName = "Icon/dish",
            FoodName = "洋葱圈",
            FoodPrice = 12,
            Hungry = 4,
            Health = -1
        },
        new FoodItem()
        {
            FoodShopName = "快乐汉堡王",
            FoodDescription = "鸡块炸得恰到好处，蘸上甜酸酱，是童年的味道。",
            FoodIconName = "Icon/dish",
            FoodName = "王道嫩香鸡块",
            FoodPrice = 15,
            Hungry = 6,
            Health = -1
        },
        new FoodItem()
        {
            FoodShopName = "快乐汉堡王",
            FoodDescription = "冰淇淋里混着奥利奥碎。甜到忧伤，凉到心底。",
            FoodIconName = "Icon/dish",
            FoodName = "奥利奥暴风雪",
            FoodPrice = 18,
            Hungry = 3,
            Health = -1
        },
        // 新增菜品 - 老妈蹄花汤
        new FoodItem()
        {
            FoodShopName = "老妈蹄花汤",
            FoodDescription = "蹄花炖得软烂脱骨，入口即化。汤白如奶，喝一口鲜掉眉毛。",
            FoodIconName = "Icon/dish",
            FoodName = "招牌老妈蹄花",
            FoodPrice = 38,
            Hungry = 10,
            Health = 2
        },
        new FoodItem()
        {
            FoodShopName = "老妈蹄花汤",
            FoodDescription = "蹄花配上酸菜，解腻开胃。能多吃两碗饭。",
            FoodIconName = "Icon/dish",
            FoodName = "酸菜蹄花",
            FoodPrice = 40,
            Hungry = 10,
            Health = 2
        },
        new FoodItem()
        {
            FoodShopName = "老妈蹄花汤",
            FoodDescription = "简单的凉菜，不简单的味道。清爽解腻，是蹄花汤的最佳拍档。",
            FoodIconName = "Icon/dish",
            FoodName = "凉拌黄瓜",
            FoodPrice = 10,
            Hungry = 2,
            Health = 1
        },
        new FoodItem()
        {
            FoodShopName = "老妈蹄花汤",
            FoodDescription = "红油抄手，皮薄馅大。辣得过瘾，香得销魂。",
            FoodIconName = "Icon/dish",
            FoodName = "红油抄手",
            FoodPrice = 15,
            Hungry = 8,
            Health = -1
        },
        new FoodItem()
        {
            FoodShopName = "老妈蹄花汤",
            FoodDescription = "米饭蒸得软硬适中，配上蹄花汤，简直是绝配。",
            FoodIconName = "Icon/dish",
            FoodName = "甄选香米饭",
            FoodPrice = 3,
            Hungry = 10,
            Health = 0
        },
        // 新增菜品 - 疯狂烤翅
        new FoodItem()
        {
            FoodShopName = "疯狂烤翅",
            FoodDescription = "最辣的等级！吃完感觉嘴巴在喷火，菊花在抗议。勇者必点。",
            FoodIconName = "Icon/dish",
            FoodName = "变态辣烤翅",
            FoodPrice = 8,
            Hungry = 3,
            Health = -2
        },
        new FoodItem()
        {
            FoodShopName = "疯狂烤翅",
            FoodDescription = "甜甜的蜂蜜味，适合不能吃辣的小朋友。烤翅界的温柔陷阱。",
            FoodIconName = "Icon/dish",
            FoodName = "蜂蜜芥末烤翅",
            FoodPrice = 8,
            Hungry = 3,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "疯狂烤翅",
            FoodDescription = "经典口味，咸香适中。不知道吃什么口味时，选它准没错。",
            FoodIconName = "Icon/dish",
            FoodName = "奥尔良烤翅",
            FoodPrice = 7,
            Hungry = 3,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "疯狂烤翅",
            FoodDescription = "黑胡椒的辛辣刺激着味蕾。口感丰富，回味无穷。",
            FoodIconName = "Icon/dish",
            FoodName = "黑胡椒烤翅",
            FoodPrice = 8,
            Hungry = 3,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "疯狂烤翅",
            FoodDescription = "蒜香浓郁，吃完记得刷牙。不然方圆十里没人敢靠近你。",
            FoodIconName = "Icon/dish",
            FoodName = "蒜香烤翅",
            FoodPrice = 8,
            Hungry = 3,
            Health = 0
        },
        // 新增菜品 - 养生粥铺
        new FoodItem()
        {
            FoodShopName = "养生粥铺",
            FoodDescription = "皮蛋和瘦肉的完美结合。咸鲜适口，暖胃更暖心。",
            FoodIconName = "Icon/dish",
            FoodName = "皮蛋瘦肉粥",
            FoodPrice = 12,
            Hungry = 8,
            Health = 1
        },
        new FoodItem()
        {
            FoodShopName = "养生粥铺",
            FoodDescription = "甜甜的南瓜粥，喝起来像是在喝甜品。美容养颜，女生最爱。",
            FoodIconName = "Icon/dish",
            FoodName = "韩式南瓜粥",
            FoodPrice = 10,
            Hungry = 6,
            Health = 1
        },
        new FoodItem()
        {
            FoodShopName = "养生粥铺",
            FoodDescription = "各种豆子混合在一起，口感丰富。喝完感觉自己充满了膳食纤维。",
            FoodIconName = "Icon/dish",
            FoodName = "五谷杂粮粥",
            FoodPrice = 8,
            Hungry = 8,
            Health = 2
        },
        new FoodItem()
        {
            FoodShopName = "养生粥铺",
            FoodDescription = "海鲜的鲜味融入粥里。虽然虾仁很小，但鲜味很大。",
            FoodIconName = "Icon/dish",
            FoodName = "鲜虾砂锅粥",
            FoodPrice = 25,
            Hungry = 10,
            Health = 1
        },
        new FoodItem()
        {
            FoodShopName = "养生粥铺",
            FoodDescription = "搭配粥的最佳伴侣。酥脆油条蘸着粥吃，是早餐的最高礼仪。",
            FoodIconName = "Icon/dish",
            FoodName = "安心油条",
            FoodPrice = 3,
            Hungry = 4,
            Health = -1
        },
        // 补充更多菜品以达到100个左右的总数
        new FoodItem()
        {
            FoodShopName = "川渝火锅冒菜",
            FoodDescription = "方便面的升华版。在红油里煮过的泡面，每一根都吸满了罪恶。",
            FoodIconName = "Icon/dish",
            FoodName = "火锅泡面",
            FoodPrice = 5,
            Hungry = 8,
            Health = -1
        },
        new FoodItem()
        {
            FoodShopName = "冰雪蜜城甜蜜蜜",
            FoodDescription = "整颗柠檬捣碎，酸爽过瘾。喝完感觉整个人都清醒了。",
            FoodIconName = "Icon/dish",
            FoodName = "霸气捣柠檬",
            FoodPrice = 6,
            Hungry = 1,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "沙县国际大酒店",
            FoodDescription = "简单的炒米粉，不简单的味道。锅气十足，吃完想舔盘子。",
            FoodIconName = "Icon/dish",
            FoodName = "鸡蛋炒米粉",
            FoodPrice = 10,
            Hungry = 10,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "深夜烧烤摊",
            FoodDescription = "烤得干干的豆角，口感独特。吃烧烤也要注意荤素搭配哦。",
            FoodIconName = "Icon/dish",
            FoodName = "烤四季豆",
            FoodPrice = 4,
            Hungry = 2,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "东北饺子馆",
            FoodDescription = "凉凉的皮冻，蘸上蒜酱。入口即化，是下酒的好菜。",
            FoodIconName = "Icon/dish",
            FoodName = "水晶皮冻",
            FoodPrice = 15,
            Hungry = 5,
            Health = 1
        },
        new FoodItem()
        {
            FoodShopName = "正宗兰州拉面",
            FoodDescription = "羊肉串的兄弟。虽然是炸的，但依然香气扑鼻。",
            FoodIconName = "Icon/dish",
            FoodName = "炸羊肉串",
            FoodPrice = 5,
            Hungry = 2,
            Health = -1
        },
        new FoodItem()
        {
            FoodShopName = "快乐汉堡王",
            FoodDescription = "酥脆的外皮，包裹着苹果馅。小心烫嘴，心急吃不了热派。",
            FoodIconName = "Icon/dish",
            FoodName = "香甜苹果派",
            FoodPrice = 8,
            Hungry = 3,
            Health = -1
        },
        new FoodItem()
        {
            FoodShopName = "老妈蹄花汤",
            FoodDescription = "肥而不腻，入口即化。配上白米饭，能吃三大碗。",
            FoodIconName = "Icon/dish",
            FoodName = "红烧肉",
            FoodPrice = 35,
            Hungry = 12,
            Health = -1
        },
        new FoodItem()
        {
            FoodShopName = "疯狂烤翅",
            FoodDescription = "可乐味的烤翅？听起来很黑暗，吃起来很惊喜。",
            FoodIconName = "Icon/dish",
            FoodName = "可乐烤翅",
            FoodPrice = 8,
            Hungry = 3,
            Health = 0
        },
        new FoodItem()
        {
            FoodShopName = "养生粥铺",
            FoodDescription = "绿豆清热解毒。夏天喝一碗，感觉整个人都凉快了。",
            FoodIconName = "Icon/dish",
            FoodName = "冰糖绿豆粥",
            FoodPrice = 6,
            Hungry = 5,
            Health = 1
        },
        new FoodItem()
        {
            FoodShopName = "0糖0脂0能量轻食",
            FoodDescription = "各种蔬菜的大杂烩。吃的时候感觉自己像只羊，吃完感觉自己升华了。",
            FoodIconName = "Icon/dish",
            FoodName = "田园蔬菜沙拉",
            FoodPrice = 25,
            Hungry = 4,
            Health = 2
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
        var extra = 0;
        var send = 0;
        if (EverydayEvent.day == DailyEvent.Platform)
        {
            extra = 5;
        }

        if (EverydayEvent.day == DailyEvent.SleepLate)
        {
            send = 10;
        }

        if (food != null&&food.Count>0)
        {
            foreach (var foodItem in food)
            {
                spend += foodItem.FoodPrice;
            }
        }
        Discounts = 0;
        if (items != null&&food != null&&food.Count>0)
        {
            foreach (var item in items)
            {
                if (spend < item.startToUse)
                {
                    continue;
                }
                Discounts++;
                switch (item.discountType)
                {
                    case DiscountType.sub: spend -= (item.discountValue+extra);break;
                    case DiscountType.change: food[Random.Range(0,food.Count)] = FoodItems[Random.Range(0, FoodItems.Count - 1)]; break;
                    case DiscountType.free: spend -= food[Random.Range(0,food.Count)].FoodPrice;break;
                    case DiscountType.Jiahao:spend = (int)(spend*Random.Range(0.8f, 1.2f)); break;
                    case DiscountType.shier: spend = (int)(spend*1.2f); break;
                }
            }
        }
        spend = Mathf.Max(0, spend);
        spend += send;
        BuyFoods = new List<FoodItem>();
        spendd = 0;
        if (money >= spend)
        {
            money -= spend;
            GameManager.Instance.PlayerMoney = money;
            //Buyed.Add(food);
            BuyFoods = food?.ToList();
            spendd = spend;
            EventsManager.Instance.EventTrigger("PlayerEatEvent",food);
            return spend;
        }
        else
        {
            Discounts = 0;
            return -1;
        }
    }
    public static List<FoodItem> BuyFoods = new List<FoodItem>();
    public static int Discounts = 0;
    public static int spendd = 0;

    public static void ShowTicket()
    {
        var ticket = Resources.Load<GameObject>("Prefab/小票结算");
        var phone = GameObject.Find("手机画面");
        if (phone != null)
        {
            UnityEngine.Object.Instantiate(ticket,phone.transform);
        }
    }
}

public class DiscountItem//:ICoupon
{
    //卷的类型
    public DiscountType discountType = DiscountType.sub;
    //折扣值，满减时为金额，折扣时为折扣率
    public int discountValue = 0;
    //起用点，只有在达到这个价格时才可以用卷
    public int startToUse = 0;
    //卷是否已经膨胀过
    public bool isBomb = false;
    //卷的过期时间
    public int expireTime = 15;
}

public static class DiscountItemExtensions
{
    public static string GetDescription(this DiscountItem item)
    {
        if(item.discountType == DiscountType.change)
        {
            return "将购物车中随机的一份餐换成随机的另一份。";
        }
        else if(item.discountType == DiscountType.free)
        {
            return "结算时减去购物车中随机一份餐的价格。";
        }
        else if(item.discountType == DiscountType.Jiahao)
        {
            return "结算的总价格会被黑客修改为原价80%~120%";
        }
        else if(item.discountType == DiscountType.shier)
        {
            return "结算时总价格为原价的120%。强制使用。";
        }
        else
        {
            return "";
        }
    }
    public static string GetDisplayName(this DiscountItem discountItem)
    {
        if (discountItem.discountType == DiscountType.sub)
        {
            if (discountItem.startToUse > 0)
            {
                return $"满{discountItem.startToUse}\n减{discountItem.discountValue}券";
            }
            else
            {
                return $"立减\n{discountItem.discountValue}元券";
            }
            
        }
        else if(discountItem.discountType == DiscountType.change)
        {
            return "换餐券";
        }
        else if(discountItem.discountType == DiscountType.free)
        {
            return "免单券";
        }
        else if(discountItem.discountType == DiscountType.Jiahao)
        {
            return "嘉豪券";
        }
        else 
        {
            return "十二折券";
        }
    }
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
public struct FoodItem
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

    public FoodItem(FoodItem other)
    {
        FoodName = other.FoodName;
        FoodShopName = other.FoodShopName;
        FoodDescription = other.FoodDescription;
        FoodIconName = other.FoodIconName;
        FoodPrice = other.FoodPrice;
        Hungry = other.Hungry;
        Health = other.Health;
    }
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
    sub ,//满减卷
    change,//换餐卷
    free ,//免单卷
    Jiahao,//嘉豪卷，随机修改花费值
    shier//十二折卷
} 