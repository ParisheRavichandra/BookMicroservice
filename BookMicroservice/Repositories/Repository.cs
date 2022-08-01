using BookManagement.Domain.Aggregates;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Interfaces;
using BookManagement.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Infrastructure.Repositories
{
    public class Repository<T>:IRepository<T> where T:EntityBase,IAggregateRoot
    {
        private readonly BookItemManagementContext context;
        public Repository(BookItemManagementContext context)
        {
            this.context = context;
        }

        public T Add(T item)
        {
            return context.Add(item).Entity;
            
        }

        public IReadOnlyCollection<T> Get()
        {

            var Data = context.Set<T>().ToList();
            return Data.AsReadOnly();
        }

        public T GetById(long id)
        {
            return context.Set<T>().Find(id);

        }


        public T Remove(T item)
        {
            return context.Remove(item).Entity;

        }

 

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
          
        }

        public T Update(T item)
        {
            return context.Update(item).Entity;
            
        }

        
    }
}
