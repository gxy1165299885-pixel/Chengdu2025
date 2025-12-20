using UnityEngine;
using Yarn.Unity;

namespace UI
{
    public class StoryController : MonoBehaviour
    {
        [SerializeField] private DialogueRunner dialogueRunner;
        
        public void StartStory(string nodename)
        {
            dialogueRunner.StartDialogue(nodename);
        }
    }
}