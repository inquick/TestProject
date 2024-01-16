using PP.Framework;

public enum MyMessageEnum
{
    MyMessageEnumBegin = MessageEnum.MessageEnumEnd,
    // ��Ŀ�¼������濪ʼ����
    LoginSuccessed,
}
public class MyMessageKey : IMessageKey
{
    private MyMessageKey() { }
    public MyMessageKey(MyMessageEnum key)
    {
        Key = (int)key;
    }
    public int Key { get; private set; }
}
