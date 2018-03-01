namespace ISD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminLogins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Drawings",
                c => new
                    {
                        DrawingId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        SmallImageUrl = c.String(),
                        LargeImageUrl = c.String(),
                        IsEnabled = c.Boolean(nullable: false),
                        PreferenceNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DrawingId);
            
            CreateTable(
                "dbo.SampleModels",
                c => new
                    {
                        ModelId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        SmallImageUrl = c.String(),
                        LargeImageUrl = c.String(),
                        IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ModelId);
            
            CreateTable(
                "dbo.PagesDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PageUrl = c.String(nullable: false),
                        Captions = c.String(nullable: false, maxLength: 100),
                        PageTitle = c.String(nullable: false),
                        Keywords = c.String(nullable: false),
                        Descriptions = c.String(nullable: false),
                        PageContent = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PagesDatas");
            DropTable("dbo.SampleModels");
            DropTable("dbo.Drawings");
            DropTable("dbo.AdminLogins");
        }
    }
}
