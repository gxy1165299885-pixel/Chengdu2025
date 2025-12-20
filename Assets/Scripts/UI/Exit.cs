using UnityEngine;

namespace UI
{
    public class Exit : MonoBehaviour
    {
        public void OnExitButtonClicked()
        {
            Application.Quit();
        }
    }
}