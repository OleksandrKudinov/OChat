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
            Wait();
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
            Reset();
        }

        public IEnumerable<BaseMessage> GetMessages()
        {
            while (_messages.Count > 0)
            {
                Wait();
                BaseMessage firstMessage = _messages.First.Value;
                _messages.RemoveFirst();
                Reset();
                yield return firstMessage;
            }
        }

        public IEnumerator<BaseMessage> GetEnumerator()
        {
            return this.GetMessages().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetMessages().GetEnumerator();
        }

        private void Wait()
        {
            while (_isLocked) ;
            _isLocked = true;
        }

        private void Reset()
        {
            _isLocked = false;
        }

        volatile bool _isLocked;

        private readonly LinkedList<BaseMessage> _messages;
    }
}
