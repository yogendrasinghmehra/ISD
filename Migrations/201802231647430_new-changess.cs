namespace ISD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newchangess : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DrawingsTypes",
                c => new
                    {
                        DrawingTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.DrawingTypeId);
            
            AddColumn("dbo.Drawings", "CountryId", c => c.Int(nullable: false));
            AddColumn("dbo.Drawings", "drawingsType_DrawingTypeId", c => c.Int());
            CreateIndex("dbo.Drawings", "drawingsType_DrawingTypeId");
            AddForeignKey("dbo.Drawings", "drawingsType_DrawingTypeId", "dbo.DrawingsTypes", "DrawingTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drawings", "drawingsType_DrawingTypeId", "dbo.DrawingsTypes");
            DropIndex("dbo.Drawings", new[] { "drawingsType_DrawingTypeId" });
            DropColumn("dbo.Drawings", "drawingsType_DrawingTypeId");
            DropColumn("dbo.Drawings", "CountryId");
            DropTable("dbo.DrawingsTypes");
        }
    }
}
