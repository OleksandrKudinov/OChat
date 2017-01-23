using System;

namespace OChat.Server
{
    public interface IChannelProvider<T>
    {
        Boolean AddChannel(String identifier, IChannel<T> channel);
        Boolean RemoveChannel(String identifier);
        IChannel<T> GetChannel(String identifier);
    }
}