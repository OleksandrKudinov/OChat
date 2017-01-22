using System;

namespace OChat.Common
{
    public sealed class TextMessage : BaseMessage
    {
        public String SenderId { get; set; }
        public String ReceiverId { get; set; }
        public String Text { get; set; }
    }
}
