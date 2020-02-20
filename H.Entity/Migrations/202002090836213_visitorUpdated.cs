namespace H.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class visitorUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Js_Visitor", "IP", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("dbo.Js_Visitor", "Country", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("dbo.Js_Visitor", "ISP", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("dbo.Js_Visitor", "JsonStr", c => c.String(maxLength: 2000, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Js_Visitor", "JsonStr", c => c.String(maxLength: 1000, storeType: "nvarchar"));
            AlterColumn("dbo.Js_Visitor", "ISP", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.Js_Visitor", "Country", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.Js_Visitor", "IP", c => c.String(maxLength: 50, storeType: "nvarchar"));
        }
    }
}
