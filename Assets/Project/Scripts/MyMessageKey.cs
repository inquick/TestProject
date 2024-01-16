using PP.Framework;

public enum MyMessageEnum
{
    MyMessageEnumBegin = MessageEnum.MessageEnumEnd,
    // 项目事件从下面开始定义
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
