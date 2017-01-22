using System;
using OChat.Common;

namespace OChat.Server
{
    internal sealed class TextMessageHandler : IMessageHandler<TextMessage>
    {
        public TextMessageHandler()
        {

        }
        public void Handle(TextMessage message)
        {
            Console.WriteLine(message.Text);
        }
    }
}
