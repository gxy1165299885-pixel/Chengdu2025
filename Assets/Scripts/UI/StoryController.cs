using UnityEngine;
using Yarn.Unity;

namespace UI
{
    /// <summary>
    /// 事件故事
    /// </summary>
    public class StoryController : MonoBehaviour
    {
        [SerializeField] private DialogueRunner dialogueRunner;
        
        public void StartStory(string nodename)
        {
            dialogueRunner.StartDialogue(nodename);
        }
    }
}