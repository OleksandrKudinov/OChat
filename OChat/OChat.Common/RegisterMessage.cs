using System;

namespace OChat.Common
{
    public sealed class RegisterMessage : BaseMessage
    {
        public String Login { get; set; }
        public String Password { get; set; }
    }
}
