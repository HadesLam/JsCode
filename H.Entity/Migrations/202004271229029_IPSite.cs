namespace H.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IPSite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Js_IPSite",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        countryCode = c.String(maxLength: 255, storeType: "nvarchar"),
                        siteUrl = c.String(maxLength: 255, storeType: "nvarchar"),
                        optime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Js_IPSite");
        }
    }
}
