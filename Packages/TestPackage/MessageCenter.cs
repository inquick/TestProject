using System;
using System.Collections.Generic;
using System.Linq;

namespace PP.Framework
{
    /// <summary>
    /// ������Ŀʹ�������Ŀǰֻ�����޲��¼���һ��������ģ�����¼�
    /// �����¼��Լ̳���IMessageKey�Ŀ�����ṩΨһ�¼���ʶ
    /// ����IMessageKey�Ķ��巽ʽ������Բο������MessageKey.cs
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
                eventTable[key] = Delegate.Remove(eventTable[key], handler);  // ��ֹ�ظ����
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
                eventTable[key] = Delegate.Remove(eventTable[key], handler);  // ��ֹ�ظ����
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