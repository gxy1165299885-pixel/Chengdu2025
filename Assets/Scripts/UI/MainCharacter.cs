using System;
using Architecture;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace UI
{
    public class MainCharacter : MonoBehaviour
    {
        [SerializeField] private Sprite normalSprite;
        [SerializeField] private Sprite sickSprite1;
        [SerializeField] private Sprite sickSprite2;
        [SerializeField] private Sprite hungrySprite;
        [SerializeField] private Sprite happySprite;
        
        [SerializeField] private Image characterRenderer;

        private void Update()
        {
            if (GameManager.Instance.HungryToDeath > 0 || GameManager.Instance.PlayerHungry < 5)
            {
                characterRenderer.sprite = hungrySprite;
            }else if (GameManager.Instance.PlayerHealth <= GameManager.MaxPlayerHealth * 0.3f)
            {
                if (Random.Range(0,2) == 0)
                {
                    characterRenderer.sprite = sickSprite1;
                }
                else
                {
                    characterRenderer.sprite = sickSprite2;
                }
            }else if (GameManager.Instance.PlayerDiscountItems.Count >= 6)
            {
                characterRenderer.sprite = happySprite;
            }
            else
            {
                characterRenderer.sprite = normalSprite;
            }
        }
    }
}