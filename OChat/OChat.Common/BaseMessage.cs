using System;

namespace OChat.Common
{
    public abstract class BaseMessage : IComparable<BaseMessage>
    {
        public Int32 MessageId { get; set; }
        public DateTime SendTimeUtc { get; set; }
        public Int32 UrgencyLevel { get; set; }

        public int CompareTo(BaseMessage other)
        {
            if(this.UrgencyLevel > other.UrgencyLevel)
            {
                return 1;
            }
            
            if(this.UrgencyLevel == other.UrgencyLevel)
            {
                if (this.SendTimeUtc > other.SendTimeUtc)
                {
                    return -1;
                }

                if (this.SendTimeUtc < other.SendTimeUtc)
                {
                    return 1;
                }

                return 0;
            }
            return -1;
        }
    }
}
