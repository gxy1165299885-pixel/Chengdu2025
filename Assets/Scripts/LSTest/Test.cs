using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Test");
        var logInfo = $"{PlatformItems.ShopperItems[0].GetFoodItems()[0].FoodName}";
        Debug.Log(logInfo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
