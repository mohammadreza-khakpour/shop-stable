using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Persistence.EF.SalesItems
{
    class SalesItemEntityMap : IEntityTypeConfiguration<SalesItem>
    {
        public void Configure(EntityTypeBuilder<SalesItem> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.ProductCount).IsRequired();
            builder.Property(_ => _.ProductCode).HasMaxLength(10);
            builder.Property(_ => _.ProductPrice);
            builder.HasOne(_ => _.Product);
            builder.HasOne(_ => _.SalesChecklist).WithMany(_ => _.Items)
                .HasForeignKey(_ => _.SalesChecklistId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
