namespace ISD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddrawingtype : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Drawings", "drawingsType_DrawingTypeId", "dbo.DrawingsTypes");
            DropIndex("dbo.Drawings", new[] { "drawingsType_DrawingTypeId" });
            RenameColumn(table: "dbo.Drawings", name: "drawingsType_DrawingTypeId", newName: "DrawingTypeId");
            AlterColumn("dbo.Drawings", "DrawingTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Drawings", "DrawingTypeId");
            AddForeignKey("dbo.Drawings", "DrawingTypeId", "dbo.DrawingsTypes", "DrawingTypeId", cascadeDelete: true);
            DropColumn("dbo.Drawings", "DrawingType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drawings", "DrawingType", c => c.Int(nullable: false));
            DropForeignKey("dbo.Drawings", "DrawingTypeId", "dbo.DrawingsTypes");
            DropIndex("dbo.Drawings", new[] { "DrawingTypeId" });
            AlterColumn("dbo.Drawings", "DrawingTypeId", c => c.Int());
            RenameColumn(table: "dbo.Drawings", name: "DrawingTypeId", newName: "drawingsType_DrawingTypeId");
            CreateIndex("dbo.Drawings", "drawingsType_DrawingTypeId");
            AddForeignKey("dbo.Drawings", "drawingsType_DrawingTypeId", "dbo.DrawingsTypes", "DrawingTypeId");
        }
    }
}
