namespace H.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MCData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Js_MCData",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        buyer_email = c.String(maxLength: 255, storeType: "nvarchar"),
                        buyer_orderno = c.String(maxLength: 255, storeType: "nvarchar"),
                        buyer_customer_reviews = c.String(maxLength: 1000, storeType: "nvarchar"),
                        optime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Js_MCData");
        }
    }
}
