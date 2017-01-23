using System;

namespace OChat.Server
{
    public interface IMultiObserver<T> : IObserver<T>
    {
        void OnCompleted(IObservable<T> value);
    }
}