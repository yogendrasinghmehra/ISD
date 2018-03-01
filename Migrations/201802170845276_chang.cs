namespace ISD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chang : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Drawings", "SmallImageUrl");
            DropColumn("dbo.SampleModels", "SmallImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SampleModels", "SmallImageUrl", c => c.String());
            AddColumn("dbo.Drawings", "SmallImageUrl", c => c.String());
        }
    }
}
