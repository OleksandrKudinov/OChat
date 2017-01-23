using System;
using OChat.Common;

namespace OChat.Server
{
    internal sealed class RequestContext
    {
        public String SessionId { get; set; }
        public Account Identity { get; set; }
        public BaseMessage Message { get; set; }
        public Result Result { get; set; }
    }
}
