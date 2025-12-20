using Architecture;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

namespace UI
{
    /// <summary>
    /// 事件故事
    /// </summary>
    public class StoryController : SingletonMono<StoryController>
    {
        [SerializeField] private DialogueRunner dialogueRunner;
        [SerializeField] private Image storyBackgroundImage;
        [SerializeField] private Sprite[] backgroundSprites;
        
        public void StartStory(string nodename)
        {
            dialogueRunner.StartDialogue(nodename);
        }
        
        /// <summary>
        /// 在Yarn对话中设置故事背景
        /// </summary>
        public static void SetStoryBackground(int index)
        {
            Instance.storyBackgroundImage.sprite = StoryController.Instance.backgroundSprites[index];
        }
    }
}