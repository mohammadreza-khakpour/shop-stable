using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Migrations.Migrations
{
    [Migration(202103171352)]
    public class _202103171352_AccountingDocumentsAdded : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.ForeignKey("FK_AccountingDocuments_SalesCheckLists").OnTable("AccountingDocuments");
            Delete.Table("AccountingDocuments");
        }

        public override void Up()
        {
            Create.Table("AccountingDocuments")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("CreationDate").AsDateTime()
                .WithColumn("SerialNumber").AsString(20).Unique()
                .WithColumn("SalesCheckListSerialNumber").AsString(20)
                .WithColumn("SalesCheckListOverallPrice").AsDouble()
                .WithColumn("SalesCheckListId").AsInt32()
                .ForeignKey("FK_AccountingDocuments_SalesCheckLists", "SalesCheckLists", "Id")
                .OnDelete(System.Data.Rule.None);
        }
    }
}
