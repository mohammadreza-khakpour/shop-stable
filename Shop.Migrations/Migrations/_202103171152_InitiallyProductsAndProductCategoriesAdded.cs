using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Migrations.Migrations
{
    [Migration(202103171152)]
    public class _202103171152_InitiallyProductsAndProductCategoriesAdded : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.ForeignKey("Fk_Products_ProductCategories").OnTable("Products");
            Delete.Table("Products");
            Delete.Table("ProductCategories");
        }

        public override void Up()
        {
            Create.Table("ProductCategories")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(50).NotNullable().Unique();

            Create.Table("Products")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(50).NotNullable().Unique()
                .WithColumn("Code").AsString(10).NotNullable().Unique()
                .WithColumn("MinimumAmount").AsInt32()
                .WithColumn("IsSufficientInStore").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("ProductCategoryId").AsInt32()
                .ForeignKey("Fk_Products_ProductCategories", "ProductCategories", "Id")
                .OnDelete(System.Data.Rule.None);
        }
    }
}
