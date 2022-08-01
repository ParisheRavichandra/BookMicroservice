using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using BookManagement.Domain.Aggregates.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagement.Infrastructure.Data.Contexts
{
    public class BookItemManagementContext: DbContext
    {
        public BookItemManagementContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Book_items> Book_items { get; set; }
        //public DbSet<Menu> Menu { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookItemManagementContext).Assembly);
        }

        
    }
}
