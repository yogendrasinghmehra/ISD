namespace ISD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chnage : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.AdminLogins",
            //    c => new
            //        {
            //            AdminId = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 20),
            //            Password = c.String(nullable: false),
            //        })
            //    .PrimaryKey(t => t.AdminId);
            
            //CreateTable(
            //    "dbo.Carriers",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 50),
            //            Email = c.String(nullable: false),
            //            DateOfBirth = c.String(nullable: false, maxLength: 20),
            //            ContactNo = c.String(nullable: false),
            //            Experience = c.String(nullable: false, maxLength: 50),
            //            Education = c.String(nullable: false, maxLength: 150),
            //            ResumeUrl = c.String(),
            //            CreatedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerQueries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 100),
                        PhoneNo = c.String(nullable: false),
                        Message = c.String(nullable: false, maxLength: 200),
                        createdDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Drawings",
            //    c => new
            //        {
            //            DrawingId = c.Int(nullable: false, identity: true),
            //            DrawingTypeId = c.Int(nullable: false),
            //            Name = c.String(nullable: false, maxLength: 100),
            //            LargeImageUrl = c.String(),
            //            IsEnabled = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.DrawingId)
            //    .ForeignKey("dbo.DrawingsTypes", t => t.DrawingTypeId, cascadeDelete: true)
            //    .Index(t => t.DrawingTypeId);
            
            //CreateTable(
            //    "dbo.DrawingsTypes",
            //    c => new
            //        {
            //            DrawingTypeId = c.Int(nullable: false, identity: true),
            //            Name = c.String(maxLength: 100),
            //        })
            //    .PrimaryKey(t => t.DrawingTypeId);
            
            //CreateTable(
            //    "dbo.SampleModels",
            //    c => new
            //        {
            //            ModelId = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 100),
            //            LargeImageUrl = c.String(),
            //            IsEnabled = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ModelId);
            
            //CreateTable(
            //    "dbo.PagesDatas",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            PageUrl = c.String(nullable: false),
            //            PageTitle = c.String(nullable: false),
            //            Keywords = c.String(nullable: false),
            //            Descriptions = c.String(nullable: false),
            //            PageContent = c.String(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Drawings", "DrawingTypeId", "dbo.DrawingsTypes");
            //DropIndex("dbo.Drawings", new[] { "DrawingTypeId" });
            //DropTable("dbo.PagesDatas");
            //DropTable("dbo.SampleModels");
            //DropTable("dbo.DrawingsTypes");
            //DropTable("dbo.Drawings");
           // DropTable("dbo.CustomerQueries");
            //DropTable("dbo.Carriers");
            //DropTable("dbo.AdminLogins");
        }
    }
}
