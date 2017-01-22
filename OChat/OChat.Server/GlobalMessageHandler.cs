using System;
using OChat.Common;

namespace OChat.Server
{
    internal sealed class GlobalMessageHandler : IMessageHandler<BaseMessage>
    {
        public GlobalMessageHandler(IMessageHandlerProvider messageHandlerProvider)
        {
            if (messageHandlerProvider == null)
            {
                throw new ArgumentNullException("Please, create and register implementation of IMessageHandlerProvider;");
            }

            _messageHandlerProvider = messageHandlerProvider;
        }

        public void Handle(BaseMessage message)
        {
            Boolean isResolved = false;

            if (message is TextMessage)
            {
                ResolveHandlerAndProcess<TextMessage>(message, out isResolved);
            }

            if (message is RegisterMessage)
            {
                ResolveHandlerAndProcess<RegisterMessage>(message, out isResolved);
            }

            if (!isResolved)
            {
                throw new Exception($"Can't handle {message.GetType().Name}. IMessageHandler<{message.GetType().Name}> instance don't exist");
            }
        }

        private void ResolveHandlerAndProcess<T>(BaseMessage message, out Boolean isResolved) where T : BaseMessage
        {
            IMessageHandler<T> handler = _messageHandlerProvider.GetMessageHandler<T>();
            isResolved = handler != null;
            handler?.Handle(message as T);
        }

        private readonly IMessageHandlerProvider _messageHandlerProvider;
    }
}
