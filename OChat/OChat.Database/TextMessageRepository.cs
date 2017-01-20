using System;
using System.Linq;
using System.Collections.Generic;
using OChat.Common;

namespace OChat.Database
{
    internal sealed class TextMessageRepository : IRepository<TextMessage>
    {
        public void Add(TextMessage entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(entity)} is null");
            }

            using (var context = new ApplicationDbContext())
            {
                context.TextMessages.Add(entity);
                // TODO use async
                context.SaveChanges();
            }
        }

        public IEnumerable<TextMessage> Find(Func<TextMessage, Boolean> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} is null");
            }

            using (var context = new ApplicationDbContext())
            {
                IEnumerable<TextMessage> result = context.TextMessages.Where(predicate).ToArray();
                return result;
            }
        }

        public TextMessage GetById(object id)
        {
            if (id == null)
            {
                throw new ArgumentNullException($"{nameof(id)} is null");
            }

            using (var context = new ApplicationDbContext())
            {
                Int32 messageId = (Int32)id;
                TextMessage result = context.TextMessages
                    .FirstOrDefault(x => x.MessageId == messageId);
                return result;
            }
        }

        public void Remove(TextMessage entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(entity)} is null");
            }

            using (var context = new ApplicationDbContext())
            {
                context.TextMessages.Remove(entity);
                //TODO use async 
                context.SaveChanges();
            }
        }
    }
}
