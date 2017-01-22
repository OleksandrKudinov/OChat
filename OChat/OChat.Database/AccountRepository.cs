using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
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
                entity.Login = entity.Login.ToLower();
                entity.AccountId = entity.AccountId ?? Guid.NewGuid().ToString();

                Boolean isNewAccount = GetById(entity.AccountId) == null;
                Boolean loginExists = context.Accounts.Any(acc => acc.Login == entity.Login);

                if (isNewAccount)
                {
                    if (loginExists)
                    {
                        throw new InvalidOperationException($"Account '{entity.Login}' already exists");
                    }
                    context.Accounts.Add(entity);
                }
                else
                {
                    // TODO allow to change login
                    if (!loginExists)
                    {
                        throw new InvalidOperationException("You are not able to change your login. Please, contact support.");
                    }
                    context.Accounts.Attach(entity);
                    context.Entry(entity).State = EntityState.Modified;
                }

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
                context.Accounts.Attach(entity);
                context.Accounts.Remove(entity);
                //TODO use async 
                context.SaveChanges();
            }
        }
    }
}
