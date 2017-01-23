using System;

namespace OChat.Server
{
    public interface IChannel<T> : IObservable<T>, IDisposable
    {
        void Send(T message);
    }
}