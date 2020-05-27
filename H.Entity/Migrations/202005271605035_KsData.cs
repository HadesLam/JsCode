namespace H.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KsData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Js_KSData",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        modelCode = c.String(maxLength: 255, storeType: "nvarchar"),
                        optime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Js_KSData");
        }
    }
}
