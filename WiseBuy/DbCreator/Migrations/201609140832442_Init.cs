namespace DbCreator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chains",
                c => new
                    {
                        ChainId = c.Long(nullable: false),
                        ChainName = c.String(),
                    })
                .PrimaryKey(t => t.ChainId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreId = c.Long(nullable: false),
                        ChainId = c.Long(nullable: false),
                        StoreName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => new { t.StoreId, t.ChainId })
                .ForeignKey("dbo.Chains", t => t.ChainId, cascadeDelete: true)
                .Index(t => t.ChainId);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        PriceId = c.Long(nullable: false, identity: true),
                        ItemPrice = c.Double(nullable: false),
                        UnitQuantity = c.String(),
                        Quantity = c.String(),
                        IsWeighted = c.String(),
                        Item_ItemId = c.Long(),
                        Store_StoreId = c.Long(),
                        Store_ChainId = c.Long(),
                    })
                .PrimaryKey(t => t.PriceId)
                .ForeignKey("dbo.Items", t => t.Item_ItemId)
                .ForeignKey("dbo.Stores", t => new { t.Store_StoreId, t.Store_ChainId })
                .Index(t => t.Item_ItemId)
                .Index(t => new { t.Store_StoreId, t.Store_ChainId });
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Long(nullable: false),
                        ItemName = c.String(),
                        ItemType = c.String(),
                        ItemDescription = c.String(),
                    })
                .PrimaryKey(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prices", new[] { "Store_StoreId", "Store_ChainId" }, "dbo.Stores");
            DropForeignKey("dbo.Prices", "Item_ItemId", "dbo.Items");
            DropForeignKey("dbo.Stores", "ChainId", "dbo.Chains");
            DropIndex("dbo.Prices", new[] { "Store_StoreId", "Store_ChainId" });
            DropIndex("dbo.Prices", new[] { "Item_ItemId" });
            DropIndex("dbo.Stores", new[] { "ChainId" });
            DropTable("dbo.Items");
            DropTable("dbo.Prices");
            DropTable("dbo.Stores");
            DropTable("dbo.Chains");
        }
    }
}
