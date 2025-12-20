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
        
        //天数变化
        public const string DayChangedEvent = "DayChangedEvent";
        
        //刷新血条
        public const string HealthUIRefreshEvent = "UIRefreshEvent";
        
        //刷新饱食度
        public const string HungryUIRefreshEvent = "HungryUIRefreshEvent";
        
        //刷新金钱
        public const string MoneyUIRefreshEvent = "MoneyUIRefreshEvent";
        
        //刷新购物车
        public const string CartUIRefreshEvent = "CartUIRefreshEvent";
        
        //商店点击进入
        public const string ShopClickedEvent = "ShopClickedEvent";
        
        //展示加入购物车的提示
        public const string ShowAddToCartTipEvent = "ShowAddToCartTipEvent";
        
        //天降神券
        public const string FreeCouponEvent = "FreeCouponEvent";
        
        
        

        #endregion

        #region 故事节点

        public const string StoryStart = "StoryStart";

        #endregion


    }
}
