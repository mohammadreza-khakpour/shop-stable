using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Persistence.EF.Products
{
    class ProductEntityMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Title).IsUnicode().IsRequired().HasMaxLength(50);
            builder.Property(_ => _.Code).IsRequired().HasMaxLength(10);
            builder.Property(_ => _.MinimumAmount);
            builder.Property(_ => _.IsSufficientInStore).IsRequired().HasDefaultValue(false);
            builder.HasOne(_ => _.ProductCategory).WithMany(_ => _.Products)
                .HasForeignKey(_ => _.ProductCategoryId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
