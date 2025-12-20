using Architecture;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// 开始按钮
    /// </summary>
    public class StartButton : MonoBehaviour
    {
        [SerializeField] private Canvas startMenuCanvas;
        [SerializeField] private Canvas mainGameCanvas;
        
        public void OnStartButtonClicked()
        {
            startMenuCanvas.gameObject.SetActive(false);
            GameManager.DisplayMainScene();
        }
    }
}