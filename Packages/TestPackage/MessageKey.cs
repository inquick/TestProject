namespace PP.Framework
{
    /// <summary>
    /// 事件唯一标识接口类
    /// </summary>
    public interface IMessageKey {
        public int Key { get; }
    }
    /// <summary>
    /// 事件唯一标识ID
    /// </summary>
    public enum MessageEnum : int
    {
        ConfigTableInit,
        OnApplicationQuit,

        MessageEnumEnd,
    }

    /// <summary>
    /// 实现事件唯一接口类的实例类
    /// 主要功能实现唯一标识从枚举向int的转换。
    /// </summary>
    public class MessageKey : IMessageKey
    {
        private MessageKey() { }
        public MessageKey(MessageEnum key) {
            Key = (int)(key);
        }
        public int Key { get; private set; }
    }
}
