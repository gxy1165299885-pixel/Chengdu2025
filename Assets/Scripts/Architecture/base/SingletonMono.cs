using UnityEngine;

namespace Architecture
{
    /// <summary>
    /// 继承自MonoBehaviour的单例模式基类
    /// </summary>
    public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
    
        /// <summary>
        /// 单例模式
        /// </summary>
        public static T Instance
        {
            get
            {
                if(_instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).ToString());
                    _instance =  obj.AddComponent<T>();
#if DEBUG_VERSION
                Debug.Log($"Create obj {obj.name}");
#endif
                }
                return _instance;
            }
        }
    
        virtual protected void Awake()
        {
            if (_instance == null) {
                _instance = GetComponent<T>();
                DontDestroyOnLoad(this);
            }
            else
                DestroyImmediate(gameObject);
        }

        //public void CreateTest()
        //{
        //    Debug.Log("SingletonMono创建成功");
        //}
    }
}
