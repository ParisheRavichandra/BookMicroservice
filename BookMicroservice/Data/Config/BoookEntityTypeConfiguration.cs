using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookManagement.Domain.Aggregates.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagement.Infrastructure.Data.Config
{
    class BoookEntityTypeConfiguration : IEntityTypeConfiguration<Book_items>
    {
        public void Configure(EntityTypeBuilder<Book_items> builder)
        {
            builder.Property(p => p.Book_name).HasMaxLength(50).IsRequired(true);
            builder.Property(p => p.Book_type).HasMaxLength(50).IsRequired(true);
            builder.Property(p => p.Book_price).HasMaxLength(50).IsRequired(true);



        }
    }

}
