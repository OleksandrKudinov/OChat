namespace OChat.Server
{
    public interface IMessageHandlerProvider
    {
        IMessageHandler<T> GetMessageHandler<T>();
    }
}
