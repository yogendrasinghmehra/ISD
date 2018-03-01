namespace ISD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chan : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Drawings", "PreferenceNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drawings", "PreferenceNo", c => c.Int(nullable: false));
        }
    }
}
