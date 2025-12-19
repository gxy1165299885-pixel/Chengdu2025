using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Architecture
{
    /// <summary>
    /// 空接口，用于实现避免，订阅事件执行时产生的装箱拆箱
    /// </summary>
    public interface IEventInfo
    {

    }

    public class EventInfo<T>:IEventInfo
    {
        public UnityAction<T> Actions;
        public EventInfo(UnityAction<T> action)
        {
            Actions += action;
        }

    }

    public class EventInfo : IEventInfo
    {
        public UnityAction Actions;
        public EventInfo(UnityAction action)
        {
            Actions += action;
        }
    }

    public class EventsManager : SingletonBase<EventsManager>
    {
        //存一个接口，因为里式替换原则使用时可以转化成子类，使用子类的字段，达到了可以用使用泛型存储委托的效果。
        private Dictionary<string, IEventInfo> eventsDictionary = new Dictionary<string, IEventInfo>();

        /// <summary>
        /// 添加事件接受者
        /// </summary>
        /// <param name="name">事件名</param>
        /// <param name="action">需要执行的事件委托</param>
        public void AddEventsListener<T>(string name, UnityAction<T> action)
        {
            if (eventsDictionary.ContainsKey(name))
            {
                if (eventsDictionary[name] is EventInfo<T> evt)
                {
                    evt.Actions += action;
                }
                else
                {
                    // 如果已有同名事件但泛型不匹配，替换为新的（更安全的行为）
                    eventsDictionary[name] = new EventInfo<T>(action);
                    Debug.Log("添加了类型不匹配的事件Listener，"+name+"事件已经被覆盖替换");
                }
            }
            else
            {
                eventsDictionary.Add(name, new EventInfo<T>(action)); 
            }
        }

        /// <summary>
        /// 添加无参事件接受者
        /// </summary>
        /// <param name="name">事件名</param>
        /// <param name="action">需要执行的事件委托</param>
        public void AddEventsListener(string name, UnityAction action)
        {
            if (eventsDictionary.ContainsKey(name))
            {
                if (eventsDictionary[name] is EventInfo evt)
                {
                    evt.Actions += action;
                }
                else
                {
                    eventsDictionary[name] = new EventInfo(action);
                    Debug.Log("添加了类型不匹配的事件Listener，" + name + "事件已经被覆盖替换");
                }
            }
            else
            {
                eventsDictionary.Add(name, new EventInfo(action));
            }
        }
        /// <summary>
        /// 事件触发
        /// </summary>
        /// <param name="name">事件名</param>
        /// <param name="info">事件参数</param>
        public void EventTrigger<T>(string name,T info)
        {
            if (eventsDictionary.ContainsKey(name))
            {
                var evt = eventsDictionary[name] as EventInfo<T>;
                if (eventsDictionary[name] != null && evt?.Actions != null)
                {
                    (eventsDictionary[name] as EventInfo<T>)?.Actions.Invoke(info);
                }
            }
        }

        /// <summary>
        /// 无参事件触发
        /// </summary>
        /// <param name="name">事件名</param>
        public void EventTrigger(string name)
        {
            if (eventsDictionary.ContainsKey(name))
            {
                var evt = eventsDictionary[name] as EventInfo;
                if (eventsDictionary[name] != null && evt?.Actions != null)
                {
                    (eventsDictionary[name] as EventInfo)?.Actions.Invoke();
                }
            }
        }
        /// <summary>
        /// 移除事件接受者
        /// </summary>
        /// <param name="name">事件名</param>
        /// <param name="action">被要求执行的事件委托</param>
        public void RemoveListener<T>(string name,UnityAction<T> action)
        {
            if (eventsDictionary.ContainsKey(name))
            {
                var evt = eventsDictionary[name] as EventInfo<T>;
                if (evt != null)
                {
                    evt.Actions -= action;
                    // 如果没有订阅者了，清除字典中的条目，避免留下 actions 为 null 的事件
                    if (evt.Actions == null)
                    {
                        eventsDictionary.Remove(name);
                    }
                }
                else
                {
                    Debug.Log("尝试移除事件"+name+"的Listener类型不匹配，已静默失败");
                }
            }
        }

        /// <summary>
        /// 移除无参事件接受者
        /// </summary>
        /// <param name="name">事件名</param>
        /// <param name="action">被要求执行的事件委托</param>
        public void RemoveListener(string name, UnityAction action)
        {
            if (eventsDictionary.ContainsKey(name))
            {
                var evt = eventsDictionary[name] as EventInfo;
                if (evt != null)
                {
                    evt.Actions -= action;
                    if (evt.Actions == null)
                    {
                        eventsDictionary.Remove(name);
                    }
                }
                else
                {
                    Debug.Log("尝试移除事件" + name + "的Listener类型不匹配，已静默失败");
                }
            }
        }
        /// <summary>
        /// 清空事件
        /// </summary>
        public void EventClear()
        {
            eventsDictionary.Clear();
        }
    }
}