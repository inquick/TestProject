using System;
using System.Collections.Generic;
using System.Linq;

namespace PP.Framework
{
    /// <summary>
    /// 根据项目使用情况，目前只保留无参事件和一个参数的模版类事件
    /// 所有事件以继承自IMessageKey的框架类提供唯一事件标识
    /// 具体IMessageKey的定义方式详情可以参考框架类MessageKey.cs
    /// </summary>
    public class MessageCenter
    {
        readonly static private Dictionary<int, Delegate> eventTable = new();

        public static void AddListener(IMessageKey msgkey, Action handler)
        {
            AddListener(msgkey.Key, handler);
        }
        private static void AddListener(int key, Action handler)
        {
            if (!eventTable.ContainsKey(key))
            {
                eventTable.Add(key, null);
            }
            else
            {
                eventTable[key] = Delegate.Remove(eventTable[key], handler);  // 防止重复添加
            }
            eventTable[key] = Delegate.Combine(eventTable[key], handler);
        }

        public static void RemoveListener(IMessageKey msgkey, Action handler)
        {
            RemoveListener(msgkey.Key, handler);
        }

        private static void RemoveListener(int key, Action handler)
        {
            if (eventTable.ContainsKey(key))
                eventTable[key] = Delegate.Remove(eventTable[key], handler);
        }

        public static void Invoke(IMessageKey key)
        {
            Invoke(key.Key);
        }

        private static void Invoke(int key)
        {
            if (eventTable.ContainsKey(key))
            {
                var invocationList = eventTable[key].GetInvocationList().Cast<Action>().ToArray();
                if (invocationList == null) return;
                foreach (var callback in invocationList)
                    callback.Invoke();
            }
        }

        public static void AddListener<T>(IMessageKey msgkey, Action<T> handler)
        {
            AddListener(msgkey.Key, handler);
        }

        private static void AddListener<T>(int key, Action<T> handler)
        {
            if (!eventTable.ContainsKey(key))
            {
                eventTable.Add(key, null);
            }
            else
            {
                eventTable[key] = Delegate.Remove(eventTable[key], handler);  // 防止重复添加
            }
            eventTable[key] = Delegate.Combine(eventTable[key], handler);
        }

        public static void RemoveListener<T>(IMessageKey msgkey, Action<T> handler)
        {
            RemoveListener(msgkey.Key, handler);
        }

        private static void RemoveListener<T>(int key, Action<T> handler)
        {
            if (eventTable.ContainsKey(key))
                eventTable[key] = Delegate.Remove(eventTable[key], handler);
        }

        public static void Invoke<T>(IMessageKey key, T arg1)
        {
            Invoke(key.Key, arg1);
        }

        private static void Invoke<T>(int key, T arg1)
        {
            if (eventTable.ContainsKey(key))
            {
                var invocationList = eventTable[key].GetInvocationList().Cast<Action<T>>().ToArray();
                if (invocationList == null) return;
                foreach (var callback in invocationList)
                    callback.Invoke(arg1);
            }
        }
    }
}