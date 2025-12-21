using Architecture;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickAudio : MonoBehaviour,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        MusicManager.Instance.PlaySound("Audio/Click");
    }
}
