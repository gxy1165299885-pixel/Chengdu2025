using Architecture;
using TapSDK.Core;
using UnityEditor;
using UnityEngine;

public class TapSDKData : SingletonBase<TapSDKData>
{
    private const string clientId = "fgbxlzkrdpmpkikvfa";
    private const string clientToken = "w7bKqWbtV4Dt1ryqgFYmZ7gExQ1nmXJxQ0c6V7WP";
    private TapTapSdkOptions coreOptions = new TapTapSdkOptions
    {
        // 客户端 ID，开发者后台获取
        clientId = clientId,
        // 客户端令牌，开发者后台获取
        clientToken = clientToken,
        // 地区，CN 为国内，Overseas 为海外
        region = TapTapRegionType.CN,
        // 语言，默认为 Auto，默认情况下，国内为 zh_Hans，海外为 en
        preferredLanguage = TapTapLanguageType.zh_Hans,
        // 是否开启日志，Release 版本请设置为 false
        enableLog = true
    };

    public TapSDKData()
    {
        TapTapSDK.Init(coreOptions);
        var IsSuccess =  TapTapSDK.IsLaunchedFromTapTapPC();
        if (IsSuccess.Result)
        {
            UnityEngine.Debug.Log(" TapTap PC 端校验通过");
            // TODO: 继续后续登录等其他业务流程
        }
        else
        {
            UnityEngine.Debug.Log(" TapTap PC 端校验未通过");
            // 停止执行后续业务流程
        }
    }

    public void LoginRequest()
    {
        
    }
    
}
