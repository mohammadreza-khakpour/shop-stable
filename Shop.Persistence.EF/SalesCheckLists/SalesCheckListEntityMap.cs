using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Persistence.EF.SalesCheckLists
{
    class SalesCheckListEntityMap : IEntityTypeConfiguration<SalesCheckList>
    {
        public void Configure(EntityTypeBuilder<SalesCheckList> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.SerialNumber).HasMaxLength(20);
            builder.Property(_ => _.RecordDate);
        }
    }
}
