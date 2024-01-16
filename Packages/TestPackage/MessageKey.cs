namespace PP.Framework
{
    /// <summary>
    /// �¼�Ψһ��ʶ�ӿ���
    /// </summary>
    public interface IMessageKey {
        public int Key { get; }
    }
    /// <summary>
    /// �¼�Ψһ��ʶID
    /// </summary>
    public enum MessageEnum : int
    {
        ConfigTableInit,
        OnApplicationQuit,

        MessageEnumEnd,
    }

    /// <summary>
    /// ʵ���¼�Ψһ�ӿ����ʵ����
    /// ��Ҫ����ʵ��Ψһ��ʶ��ö����int��ת����
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
