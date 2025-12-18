using UnityEngine;

namespace Architecture
{
    /// <summary>
    /// 纯C#单例模式基类
    /// </summary>
    public class SingletonBase<T> where T:new()
    {

        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new T();
                return _instance;
            }
        }
    }
}



