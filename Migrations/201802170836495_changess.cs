namespace ISD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changess : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PagesDatas", "Captions");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PagesDatas", "Captions", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
