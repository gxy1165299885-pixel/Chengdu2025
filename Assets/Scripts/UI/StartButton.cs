using UnityEngine;

namespace UI
{
    public class StartButton : MonoBehaviour
    {
        [SerializeField] private Canvas startMenuCanvas;
        [SerializeField] private Canvas mainGameCanvas;
        
        public void OnStartButtonClicked()
        {
            startMenuCanvas.gameObject.SetActive(false);
            mainGameCanvas.gameObject.SetActive(true);
        }
    }
}