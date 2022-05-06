namespace seminarska1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Knjigas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naslov = c.String(),
                        Založba = c.String(),
                        Datum = c.DateTime(nullable: false),
                        Knjiznicaid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Knjiznicas", t => t.Knjiznicaid, cascadeDelete: true)
                .Index(t => t.Knjiznicaid);
            
            CreateTable(
                "dbo.Zaposlenis",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Priimek = c.String(),
                        DatumRojstva = c.DateTime(nullable: false),
                        KnjiznicaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Knjiznicas", t => t.KnjiznicaId, cascadeDelete: true)
                .Index(t => t.KnjiznicaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zaposlenis", "KnjiznicaId", "dbo.Knjiznicas");
            DropForeignKey("dbo.Knjigas", "Knjiznicaid", "dbo.Knjiznicas");
            DropIndex("dbo.Zaposlenis", new[] { "KnjiznicaId" });
            DropIndex("dbo.Knjigas", new[] { "Knjiznicaid" });
            DropTable("dbo.Zaposlenis");
            DropTable("dbo.Knjigas");
        }
    }
}
