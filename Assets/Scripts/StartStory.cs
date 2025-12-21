using Architecture;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

namespace DefaultNamespace
{
    public class StartStory : SingletonMono<StartStory>
    {
        [SerializeField] private Image characterImage;
        [SerializeField] private Sprite[] characterSprites;
        
        [YarnCommand("CharacterHappy")]
        public static void CharacterHappy()
        {
            Instance.characterImage.sprite = Instance.characterSprites[0];
        }
        
        [YarnCommand("CharacterAmaze")]
        public static void CharacterAmaze()
        {
            Instance.characterImage.sprite = Instance.characterSprites[1];
        }
        
        [YarnCommand("CharacterNormal")]
        public static void CharacterNormal()
        {
            Instance.characterImage.sprite = Instance.characterSprites[2];
        }
        
        [YarnCommand("CharacterSigh")]
        public static void CharacterSigh()
        {
            Instance.characterImage.sprite = Instance.characterSprites[3];
        }
        
        [YarnCommand("CharacterDigust1")]
        public static void CharacterDigust1()
        {
            Instance.characterImage.sprite = Instance.characterSprites[4];
        }
        
        [YarnCommand("CharacterDigust2")]
        public static void CharacterDigust2()
        {
            Instance.characterImage.sprite = Instance.characterSprites[5];
        }
    }
}