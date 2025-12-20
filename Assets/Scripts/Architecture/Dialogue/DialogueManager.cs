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
            "今天的早八就像是一场渡劫...",
            "食堂阿姨的手抖得像帕金森，我的肉啊...",
            "下个月的生活费怎么还没到账...",
            "听说隔壁寝室又脱单了，而我只有脱发。",
            "这节课的PPT催眠效果堪比褪黑素。",
            "如果不买那杯奶茶，我现在就是富婆了。",
            "我想在这个城市买房，大概还需要向天再借五百年。",
            "今天天气不错，适合在寝室躺平。",
            "只要我睡得够快，饥饿就追不上我。",
            "什么时候才能实现车厘子自由？",
            "这学期的学分就像我的余额，岌岌可危。",
            "又是想当咸鱼的一天。",
            "那个打折的洗发水好像快卖完了，得去抢。",
            "为什么周末的时间总是过得比平时快两倍？",
            "今天也是努力在这个城市苟住的一天。",
        };
        
        string[] HungryTalk =
        {
            "我的胃在开交响乐演奏会了...",
            "现在看谁都像行走的鸡腿。",
            "饿得能吃下一头牛，或者两份食堂的免费汤。",
            "如果空气能吃饱，我大概已经撑死了。",
            "别跟我说话，我现在只想跟米饭通过食道进行深入交流。",
            "饿昏头了，刚才差点把橡皮擦当糖吃了。",
            "为了省钱吃土，结果发现土也不便宜。",
            "此时此刻，唯有泡面能解千愁。",
            "感觉身体被掏空，急需碳水化合物填充。",
            "再不吃饭，我就要通过光合作用生存了。",
            "好想吃火锅、串串、冒菜、烤鱼...哪怕是馒头也行啊。",
            "我的灵魂已经出窍去觅食了。",
            "这就是贫穷的味道吗？有点酸，主要是胃酸。",
            "谁能请我吃顿饭，我愿意叫他一声义父。",
            "饿得眼冒金星，这算不算免费的特效？",
        };
        
        string[] HappyTalk =
        {
            "今天食堂阿姨多给了我一块肉！这是爱的供养！",
            "捡到一块钱！巨款！今天的快乐是它给的！",
            "抢到了超市的临期打折面包，感觉自己是理财大师。",
            "不用早起的一天，空气都是甜的。",
            "居然没挂科！感谢老师不杀之恩！",
            "发生活费了！虽然还完花呗就没了，但至少曾经拥有。",
            "今天妆化得不错，可惜没人约，只能孤芳自赏。",
            "买到了半价的奶茶，四舍五入等于不要钱！",
            "感觉今天运气爆棚，是不是该去买张彩票？",
            "刚刚那只流浪猫让我摸了！它喜欢我！",
            "终于把那个难搞的作业写完了，爽！",
            "今天的天空蓝得像动漫里的场景一样。",
            "体重轻了两斤！虽然可能是饿瘦的，但也是瘦！",
            "发现了一首好听的歌，单曲循环中~",
            "生活虽然苦，但今天的糖分超标了！",
        };
        
        string[] IllTalk =
        {
            "生病了才发现，健康比钱重要...一点点。",
            "头好痛，感觉脑子里在装修。",
            "药好贵啊，这吃的不是药，是我的血汗钱。",
            "我想回家，我想喝妈妈煮的粥...",
            "咳得肺都要出来了，有没有人能帮我塞回去？",
            "以后再也不熬夜了...大概吧。",
            "感觉自己像个废人，连下床都需要勇气。",
            "这就是不穿秋裤的报应吗？",
            "体温计上的数字比我的绩点还高。",
            "鼻子堵住了，现在呼吸都是一种奢望。",
            "生病的时候，孤独感会被放大一万倍。",
            "浑身酸痛，像是被一群大汉围殴了一顿。",
            "如果病魔能被钱收买就好了，可惜我没钱。",
            "脆弱的女大学生在线求安慰...",
            "只要让我好起来，我愿意吃一周的素！",
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