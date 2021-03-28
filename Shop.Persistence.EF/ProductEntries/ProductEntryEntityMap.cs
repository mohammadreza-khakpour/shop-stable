using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Persistence.EF.ProductEntries
{
    class ProductEntryEntityMap : IEntityTypeConfiguration<ProductEntry>
    {
        public void Configure(EntityTypeBuilder<ProductEntry> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.ProductCount).IsRequired();
            builder.Property(_ => _.EntryDate);
            builder.Property(_ => _.ProductCode).IsRequired();
            builder.Property(_ => _.EntrySerialNumber).HasMaxLength(20);
            builder.HasOne(_ => _.Product);

        }
    }
}
