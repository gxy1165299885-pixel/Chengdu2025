namespace Architecture
{
    /// <summary>
    /// 用来存放特定字符串名称的静态类
    /// </summary>
    public static class Constants {
        #region 事件名称

        public const string DayEndEvent = "DayEndEvent";
        public const string DayStartEvent = "DayStartEvent";
        public const string GameEndEvent = "GameEndEvent";
        public const string PlayerDeadEvent = "PlayerDeadEvent";
        public const string PlayerEatEvent = "PlayerEatEvent";
        
        //刷新血条
        public const string HealthUIRefreshEvent = "UIRefreshEvent";
        
        //刷新购物车
        public const string CartUIRefreshEvent = "CartUIRefreshEvent";
        
        //商店点击进入
        public const string ShopClickedEvent = "ShopClickedEvent";
        
        //优惠券点击使用
        public const string CouponUseClickedEvent = "CouponUseClickedEvent";
        

        #endregion

        #region 故事节点

        public const string StoryStart = "StoryStart";

        #endregion


    }
}
