using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Persistence.EF.AccountingDocuments
{
    class AccountingDocumentsEntityMap : IEntityTypeConfiguration<AccountingDocument>
    {
        public void Configure(EntityTypeBuilder<AccountingDocument> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.CreationDate);
            builder.Property(_ => _.SerialNumber).HasMaxLength(20);
            builder.HasOne(_ => _.SalesCheckList).WithMany(_ => _.Documents)
                .HasForeignKey(_ => _.SalesCheckListId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
