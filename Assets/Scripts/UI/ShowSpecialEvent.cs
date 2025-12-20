using System;
using UnityEngine;

public class ShowSpecialEvent : MonoBehaviour
{
    private void OnEnable()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.SetAsLastSibling();
    }

    public void QuitUI()
    {
        Destroy(gameObject);
    }
}
