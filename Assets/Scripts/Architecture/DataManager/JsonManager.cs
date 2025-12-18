using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Architecture
{
    public class JsonManager : SingletonBase<JsonManager>
    {
        /// <summary>
        /// 使用Newtonsoft.JSON存储数据为json形式
        /// </summary>
        /// <param name="data">需要存储的对象</param>
        /// <param name="fileName">文件名</param>
        public void SaveJson(object data, string fileName)
        {
            //获得存储路径名
            string path = Application.persistentDataPath + $"/{fileName}.json";

            string jsonStr = "";

            Type dataType = data.GetType();
        
            jsonStr = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            //存储为json文件
            File.WriteAllText(path, jsonStr);
        }

        public T LoadJson<T>(string fileName) where T : new()
        {
            //获取文件路径
            var path = Application.persistentDataPath + $"/{fileName}.json";
            if (!File.Exists(path))
                return new T();
        
            var jsonStr = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<T>(jsonStr);
        }

        public void DeleteJson(string fileName)
        {
            var path = Application.persistentDataPath + $"/{fileName}.json";

            if (File.Exists(path))
                File.Delete(path);
        }


    }
}
