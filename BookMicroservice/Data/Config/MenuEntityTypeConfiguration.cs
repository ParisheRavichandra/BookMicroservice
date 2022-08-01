using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookManagement.Domain.Aggregates.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagement.Infrastructure.Data.Config
{
    public class MenuEntityTypeConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure (EntityTypeBuilder<Menu>builder)
        {
            
            builder.Property(p => p.Book_name).IsRequired(true).HasMaxLength(50);
            builder.Property(p => p.Book_type).IsRequired(true).HasMaxLength(50);
            builder.Property(p => p.Book_price).IsRequired(true).HasMaxLength(50);

        }

        
    }

    
}
