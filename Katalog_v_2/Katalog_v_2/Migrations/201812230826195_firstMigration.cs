namespace Katalog_v_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bludoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rezepts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        bludId = c.Int(nullable: false),
                        Ingrid = c.String(),
                        soder = c.String(),
                        RezeptData = c.String(),
                        Image = c.Binary(),
                        ImageMimeType = c.String(),
                        Name = c.String(),
                        Bludo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bludoes", t => t.Bludo_Id)
                .Index(t => t.Bludo_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rezepts", "Bludo_Id", "dbo.Bludoes");
            DropIndex("dbo.Rezepts", new[] { "Bludo_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Rezepts");
            DropTable("dbo.Bludoes");
        }
    }
}
