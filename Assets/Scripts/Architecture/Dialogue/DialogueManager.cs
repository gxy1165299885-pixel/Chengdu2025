using System;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Yarn.Unity;
using Random = UnityEngine.Random;

namespace Architecture.Dialogue
{
    /// <summary>
    /// 游戏内角色自言自语
    /// </summary>
    public class DialogueManager : SingletonMono<DialogueManager>
    {
        [SerializeField] private TextMeshProUGUI dialogueText;

        private CancellationTokenSource _cancellationTokenSource;
        
        string[] NormalTalk =
        {
            "距离下个月生活费到账还有...天？这日子没法过了。",
            "刚才那个外卖小哥看我的眼神，是不是在暗示我有隐藏红包没领？",
            "今天的步数能不能换点积分？哪怕换个满减券也行啊。",
            "听说隔壁寝室的那个谁，抢到了五折券，这就是欧皇的嘴脸吗？",
            "我的钱包比我的脸还干净，这合理吗？",
            "如果收集优惠券是一门必修课，我大概能拿满绩点。",
            "为了凑满减，我把这辈子的数学天赋都用上了。",
            "这节课的PPT上要是印着优惠码，我绝对不会睡着。",
            "我想在这个城市立足，首先得立足于各大外卖平台的会员体系。",
            "今天天气不错，适合去食堂门口蹲点捡漏...啊不是，是散步。",
            "只要我点外卖的手速够快，贫穷就追不上我...才怪。",
            "什么时候才能实现外卖自由？哪怕是免配送费自由也行啊。",
            "这学期的学分和我的优惠券库存一样，岌岌可危。",
            "又是想当咸鱼的一天，但咸鱼也得吃饭啊。",
            "那个打折的洗发水...算了，还是先看看今天的特价午餐吧。",
        };
        
        string[] HungryTalk =
        {
            "我的胃在抗议，它说它想念那个满30减15的黄焖鸡。",
            "现在看谁都像行走的鸡腿，尤其是那个穿黄色衣服的同学。",
            "饿得能吃下一头牛，前提是那头牛能用优惠券抵扣。",
            "如果空气能吃饱，我大概已经撑死了，毕竟喝西北风管饱。",
            "别跟我说话，我现在只想跟米饭通过食道进行深入交流，哪怕是隔夜饭。",
            "饿昏头了，刚才差点把传单当优惠券吃了。",
            "为了省钱吃土，结果发现土也不便宜，还得付运费。",
            "此时此刻，唯有泡面能解千愁，但泡面也涨价了啊！",
            "感觉身体被掏空，急需碳水化合物填充，谁有临期面包？",
            "再不吃饭，我就要通过光合作用生存了，我是向日葵吗？",
            "好想吃火锅、串串、冒菜...哪怕是别人吃剩的...不行，要有骨气！",
            "我的灵魂已经出窍去觅食了，肉体还在等外卖红包到账。",
            "这就是贫穷的味道吗？有点酸，主要是胃酸，还有过期的柠檬水味。",
            "谁能请我吃顿饭，我愿意把我的外卖会员借他用一天！",
            "饿得眼冒金星，这算不算免费的特效？能不能换个馒头？",
        };
        
        string[] HappyTalk =
        {
            "抢到了！满20减10的大额神券！我是天选之子！",
            "今天食堂阿姨手没抖，多给了我一块肉！这是爱的供养！",
            "捡到一块钱！巨款！今天的快乐是它给的，能买个馒头了！",
            "抢到了超市的临期打折面包，感觉自己是华尔街之狼。",
            "不用早起的一天，而且还领到了免配送费券，空气都是甜的。",
            "居然没挂科！感谢老师不杀之恩！为了庆祝，我要加个蛋！",
            "发生活费了！虽然还完花呗就没了，但至少曾经拥有过那串数字。",
            "买到了半价的奶茶，四舍五入等于不要钱！我赚了！",
            "感觉今天运气爆棚，是不是该去买张彩票？算了，两块钱也是钱。",
            "刚刚那只流浪猫让我摸了！它是不是闻到了我身上的肉包子味？",
            "终于把那个难搞的作业写完了，爽！奖励自己看一眼外卖软件。",
            "今天的天空蓝得像动漫里的场景一样，适合点个外卖在阳台吃。",
            "体重轻了两斤！虽然可能是饿瘦的，但省了减肥药的钱！",
            "发现了一首好听的歌，单曲循环中~ 听歌不花钱，真好。",
            "生活虽然苦，但今天的拼手气红包开出了5块钱！巨款！",
        };
        
        string[] IllTalk =
        {
            "生病了才发现，健康比钱重要...但没钱治病更要命。",
            "头好痛，感觉脑子里在装修，装修费谁出？",
            "药好贵啊，这吃的不是药，是我的血汗钱，是我的鸡腿饭！",
            "我想回家，我想喝妈妈煮的粥...外卖的粥全是水。",
            "咳得肺都要出来了，有没有人能帮我塞回去？顺便帮我领个药店优惠券。",
            "以后再也不熬夜抢券了...大概吧，除非是大额券。",
            "感觉自己像个废人，连下床拿外卖都需要勇气。",
            "这就是不穿秋裤的报应吗？还是因为没钱买羽绒服？",
            "体温计上的数字比我的绩点还高，也比我的余额高。",
            "鼻子堵住了，现在呼吸都是一种奢望，就像我的财务自由一样遥远。",
            "生病的时候，孤独感会被放大一万倍，尤其是看到余额的时候。",
            "浑身酸痛，像是被一群大汉围殴了一顿，或者被生活暴打了一顿。",
            "如果病魔能被优惠券收买就好了，我有好多满减券...",
            "脆弱的女大学生在线求安慰...或者求个感冒灵。",
            "只要让我好起来，我愿意吃一周的素！反正肉也吃不起！",
        };

        private void OnEnable()
        {
            EventsManager.Instance.AddEventsListener<int>(Constants.DayStartEvent, OnDayStart);   
            EventsManager.Instance.AddEventsListener<int>(Constants.DayEndEvent, OnDayEnd);
        }
        
        private void OnDisable()
        {
            EventsManager.Instance.RemoveListener<int>(Constants.DayStartEvent, OnDayStart);   
            EventsManager.Instance.RemoveListener<int>(Constants.DayEndEvent, OnDayEnd);
        }

        private void OnDayStart(int day)
        {
            
        }
        
        private void OnDayEnd(int day)
        {
            
        }

        private async void StartDialogue()
        {
            try
            {
                while (!_cancellationTokenSource.IsCancellationRequested)
                {
                    var talk = GetRandomDialogue();
                    dialogueText.text = talk;
                    dialogueText.TypeText(talk, 3f);
                    await Task.Delay(Random.Range(12000, 18000), _cancellationTokenSource.Token);
                }
            }
            catch (Exception e)
            {
                // ignored
            }
        }
        private string GetRandomDialogue()
        {
            
            
            // TODO 根据游戏进度添加更多对话类型
            int index = Random.Range(0, NormalTalk.Length);
            return NormalTalk[index];
        }
    }
}