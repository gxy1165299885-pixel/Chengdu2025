using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Architecture
{
    public class ResourceManager : SingletonBase<ResourceManager>
    {
        /// <summary>
        /// 同步加载Resources下的资源
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">在Rescources文件夹下的路径</param>
        /// <param name="parent">实例化后设置的父对象</param>
        /// <returns></returns>
        public T Load<T>(string path, Transform parent = null) where T : Object
        {
            T res = Resources.Load<T>(path);
            if (res is GameObject)
                return GameObject.Instantiate(res, parent);
            else
                return res;
        }
        /// <summary>
        /// 异步加载Resources下的资源
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">在Resources文件夹下的路径</param>
        /// <param name="callback">加载完成后的回调函数</param>
        /// <param name="parent">实例化后设置的父对象</param>
        public void LoadAsync<T>(string path, UnityAction<T> callback, Transform parent = null) where T : Object
        {
            MonoController.Instance.StartCoroutine(RealLoadAsync<T>(path, callback, parent));
        }

        private IEnumerator RealLoadAsync<T>(string path, UnityAction<T> callback, Transform parent) where T : Object
        {
            ResourceRequest r = Resources.LoadAsync<T>(path);
            yield return r;
            if (r.asset is GameObject)
                callback(GameObject.Instantiate(r.asset, parent) as T);
            else
                callback(r.asset as T);
        }
    }
}
