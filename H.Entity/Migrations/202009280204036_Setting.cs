namespace H.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Setting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Js_Setting",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        name = c.String(maxLength: 255, storeType: "nvarchar"),
                        value = c.String(maxLength: 255, storeType: "nvarchar"),
                        control = c.String(maxLength: 255, storeType: "nvarchar"),
                        optime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Js_Setting");
        }
    }
}
