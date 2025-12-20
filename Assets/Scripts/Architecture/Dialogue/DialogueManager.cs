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
            string[] NormalTalk =
            {
                "What a beautiful day!",
                "I wonder what's for lunch.",
                "I should really start exercising more.",
                "Did I leave the stove on?",
                "I love the sound of rain.",
                "Time flies when you're having fun.",
                "I need to call my mom.",
                "This book is really interesting.",
                "I should learn to play an instrument.",
                "Traveling is so exciting!"
            };
            
            // TODO 根据游戏进度添加更多对话类型
            int index = Random.Range(0, NormalTalk.Length);
            return NormalTalk[index];
        }
    }
}