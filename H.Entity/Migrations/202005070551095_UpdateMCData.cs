namespace H.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMCData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Js_MCData", "IsQueryOK", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Js_MCData", "IsQueryOK");
        }
    }
}
