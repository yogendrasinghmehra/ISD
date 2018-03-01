namespace ISD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drawings", "DrawingType", c => c.Int(nullable: false));
            DropColumn("dbo.Drawings", "CountryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drawings", "CountryId", c => c.Int(nullable: false));
            DropColumn("dbo.Drawings", "DrawingType");
        }
    }
}
