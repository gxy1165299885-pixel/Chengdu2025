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
        
        private bool isSick = false;

        private void Update()
        {
            if (GameManager.Instance.HungryToDeath > 0 || GameManager.Instance.PlayerHungry < 5)
            {
                characterRenderer.sprite = hungrySprite;
                isSick = false;
            }else if (GameManager.Instance.PlayerHealth <= GameManager.MaxPlayerHealth * 0.3f)
            {
                if (isSick==false)
                {
                    if (Random.Range(0, 2) == 0)
                    {
                        characterRenderer.sprite = sickSprite1;
                    }
                    else
                    {
                        characterRenderer.sprite = sickSprite2;
                    }

                    isSick = true;
                }
            }else if (GameManager.Instance.PlayerDiscountItems.Count >= 6)
            {
                characterRenderer.sprite = happySprite;
                isSick = false;
            }
            else
            {
                characterRenderer.sprite = normalSprite;
                isSick = false;
            }
        }
    }
}