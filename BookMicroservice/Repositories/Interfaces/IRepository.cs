using BookManagement.Domain.Aggregates;
using BookManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Interfaces
{
    public interface IRepository<T> where T:EntityBase,IAggregateRoot
    {
        T Add(T item);
        T Update(T item);
        T Remove(T item);
        IReadOnlyCollection<T> Get();
        Task<int> SaveAsync();
        T GetById(long id);
        
    }
}
