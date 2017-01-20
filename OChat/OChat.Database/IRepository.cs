using System;
using System.Collections.Generic;

namespace OChat.Database
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Remove(T entity);
        T GetById(Object id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
    }
}
