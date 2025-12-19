using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Yarn.Unity;
using Random = UnityEngine.Random;

namespace Architecture.Dialogue
{
    public class DialogueManager : SingletonMono<DialogueManager>
    {
        [SerializeField] private DialogueRunner dialogueRunner;

        private CancellationTokenSource _cancellationTokenSource;

        protected override void Awake()
        {
            base.Awake();
            EventsManager.Instance.AddEventsListener(Constants.DayStartEvent, OnDayStart);   
            EventsManager.Instance.AddEventsListener(Constants.DayEndEvent, OnDayEnd);
        }

        private void OnDayStart()
        {
            
        }
        
        private void OnDayEnd()
        {
            
        }

        private async void StartDialogue()
        {
            try
            {
                while (!_cancellationTokenSource.IsCancellationRequested)
                {
                    //dialogueRunner.StartDialogue();
                    await Task.Delay(Random.Range(12000, 18000), _cancellationTokenSource.Token);
                }
            }
            catch (Exception e)
            {
                // ignored
            }
        }
    }
}