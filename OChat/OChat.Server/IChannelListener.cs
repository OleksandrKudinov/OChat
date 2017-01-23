using System;

namespace OChat.Server
{
    public interface IChannelListener<T> : IMultiObserver<T>, IDisposable
    {
        void StartListen(IChannel<T> channel);
        void StopListen(IChannel<T> channel);
    }
}