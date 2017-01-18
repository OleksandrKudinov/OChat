using System;

namespace OChat.Common
{
    public abstract class BaseMessage
    {
        public Int32 MessageId { get; set; }
        public DateTime SendTimeUtc { get; set; }
    }
}
