namespace Katalog_v_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rezepts", "Bludo_Id", "dbo.Bludoes");
            DropIndex("dbo.Rezepts", new[] { "Bludo_Id" });
            AlterColumn("dbo.Rezepts", "Bludo_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Rezepts", "Bludo_Id");
            AddForeignKey("dbo.Rezepts", "Bludo_Id", "dbo.Bludoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rezepts", "Bludo_Id", "dbo.Bludoes");
            DropIndex("dbo.Rezepts", new[] { "Bludo_Id" });
            AlterColumn("dbo.Rezepts", "Bludo_Id", c => c.Int());
            CreateIndex("dbo.Rezepts", "Bludo_Id");
            AddForeignKey("dbo.Rezepts", "Bludo_Id", "dbo.Bludoes", "Id");
        }
    }
}
