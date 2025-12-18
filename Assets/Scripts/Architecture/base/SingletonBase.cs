using UnityEngine;

namespace Architecture
{
    /// <summary>
    /// 纯C#单例模式基类
    /// </summary>
    public class SingletonBase<T> where T:new()
    {

        private static T instance;

        //private SingletonBase() { }

        public static T Instance
        {
            get
            {
                if (instance == null)
                    instance = new T();
                return instance;
            }
        }

        public void CreateTest()
        {
            Debug.Log("SingletonBase创建成功");
        }



    }
}



