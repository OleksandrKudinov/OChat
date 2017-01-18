namespace OChat.Server
{
    public interface IMessageHandler<in T>
    {
        void Handle(T message);
    }
}
