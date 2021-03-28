using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Persistence.EF.Warehouses
{
    class WarehouseEntityMap : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.ProductCount);
            builder.HasOne(_ => _.Product);
        }
    }
}
