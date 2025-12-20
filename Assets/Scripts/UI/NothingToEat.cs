using System;
using Architecture;
using TMPro;
using UnityEngine;

namespace UI
{
    public class NothingToEat : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI infoText;

        private void OnEnable()
        {
            infoText.gameObject.SetActive(GameManager.Instance.ShoppingCartItems.Count == 0);
        }
    }
}