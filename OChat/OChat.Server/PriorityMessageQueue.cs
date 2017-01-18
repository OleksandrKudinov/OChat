using OChat.Common;
using System.Collections.Generic;
using System.Collections;

namespace OChat.Server
{
    public class PriorityMessageQueue : IMessageHandler<BaseMessage>, IEnumerable<BaseMessage>
    {
        public PriorityMessageQueue()
        {
            _messages = new LinkedList<BaseMessage>();
        }

        public void Handle(BaseMessage message)
        {
            if (_messages.Count == 0)
            {
                _messages.AddFirst(message);
            }
            else
            {
                LinkedListNode<BaseMessage> current = _messages.Last;

                while (message.CompareTo(current.Value) == 1 && current.Previous != null)
                {
                    current = current.Previous;
                }

                if (message.CompareTo(current.Value) == 1)
                {
                    _messages.AddBefore(current, message);
                }
                else
                {
                    _messages.AddAfter(current, message);
                }
            }
        }

        public IEnumerable<BaseMessage> GetMessage()
        {
            while (_messages.Count > 0)
            {
                BaseMessage firstMessage = _messages.First.Value;
                _messages.RemoveFirst();
                yield return firstMessage;
            }
        }

        public IEnumerator<BaseMessage> GetEnumerator()
        {
            return this.GetMessage().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetMessage().GetEnumerator();
        }

        private readonly LinkedList<BaseMessage> _messages;
    }
}
