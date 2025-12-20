using System;
using Architecture;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class AddToCartTip : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        
        public void ShowTip()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.FadeOut(1.5f);
            _canvasGroup.transform.MoveBy(Vector2.up * 50, 1.5f);
            Invoke(nameof(HideTip), 1.5f);
        }
        
        public void HideTip()
        {
            Destroy(gameObject);
        }
    }
}