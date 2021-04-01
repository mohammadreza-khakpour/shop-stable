using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Migrations.Migrations
{
    [Migration(202103171340)]
    public class _202103171340_SalesItemsAndSalesCheckListsAdded : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.ForeignKey("FK_SalesItems_Products").OnTable("SalesItems");
            Delete.ForeignKey("FK_SalesItems_SalesCheckLists").OnTable("SalesItems");
            Delete.Table("SalesItems");
            Delete.Table("SalesCheckLists");
        }

        public override void Up()
        {
            Create.Table("SalesCheckLists")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("SerialNumber").AsString(20).Unique()
                .WithColumn("CustomerFullName").AsString(50)
                .WithColumn("OverAllProductCount").AsInt32()
                .WithColumn("OverAllProductPrice").AsDouble()
                .WithColumn("RecordDate").AsDateTime();

            Create.Table("SalesItems")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("ProductCount").AsInt32().NotNullable()
                .WithColumn("ProductCode").AsString(10)
                .WithColumn("ProductPrice").AsDouble()
                .WithColumn("ProductId").AsInt32()
                .ForeignKey("FK_SalesItems_Products", "Products", "Id")
                .OnDelete(System.Data.Rule.None)
                .WithColumn("SalesChecklistId").AsInt32()
                .ForeignKey("FK_SalesItems_SalesCheckLists", "SalesCheckLists", "Id")
                .OnDelete(System.Data.Rule.Cascade);


        }

    }
}
