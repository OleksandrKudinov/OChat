using System;
using System.Linq;
using System.Collections.Generic;
using OChat.Common;

namespace OChat.Database
{
    internal sealed class AccountRepository : IRepository<Account>
    {
        public void Add(Account entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(entity)} is null");
            }

            using (var context = new ApplicationDbContext())
            {
                context.Accounts.Add(entity);
                // TODO use async
                context.SaveChanges();
            }
        }

        public IEnumerable<Account> Find(Func<Account, Boolean> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} is null");
            }

            using (var context = new ApplicationDbContext())
            {
                IEnumerable<Account> result = context.Accounts.Where(predicate).ToArray();
                return result;
            }
        }

        public Account GetById(Object id)
        {
            String accountId = id as String;
            if (String.IsNullOrWhiteSpace(accountId))
            {
                throw new ArgumentNullException($"{nameof(id)} is null");
            }

            using (var context = new ApplicationDbContext())
            {
                Account result = context.Accounts
                    .FirstOrDefault(account => account.AccountId == accountId);
                return result;
            }
        }

        public void Remove(Account entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(entity)} is null");
            }

            using (var context = new ApplicationDbContext())
            {
                context.Accounts.Remove(entity);
                //TODO use async 
                context.SaveChanges();
            }
        }
    }
}
