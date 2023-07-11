using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Core.Models;

namespace UnitOfWorkDemo.Infrastructure.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<ProductDetails>
    {
       public void Configure(EntityTypeBuilder<ProductDetails> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p =>p.ProductName).HasMaxLength(100).IsRequired();
            builder.Property(p =>p.ProductDescription).HasMaxLength(200).IsRequired();
            builder.Property(p => p.ProductPrice).HasDefaultValue(0);
            builder.Property(p =>p.ProductStock).HasDefaultValue(0);
          
        }
    }
}
