using System.Collections;
using UnityEngine;

public class ShowDialogUI : MonoBehaviour
{
    CanvasGroup canvasGroup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(Fade());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(2f);
        float time = 1f;
        while (time > 0f)
        {
            time -= Time.deltaTime;
            canvasGroup.alpha = time;
            yield return null;
        }
        Destroy(gameObject);
    }
}
