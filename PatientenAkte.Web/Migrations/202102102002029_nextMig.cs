namespace PatientenAkte.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nextMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arzts",
                c => new
                    {
                        ArztNr = c.Int(nullable: false, identity: true),
                        ArztTitle = c.String(maxLength: 50),
                        ArztVorname = c.String(maxLength: 50),
                        ArztNachname = c.String(maxLength: 50),
                        PatientenNr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArztNr)
                .ForeignKey("dbo.Patients", t => t.PatientenNr, cascadeDelete: true)
                .Index(t => t.PatientenNr);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientenNr = c.Int(nullable: false, identity: true),
                        Vorname = c.String(maxLength: 50),
                        Nachname = c.String(nullable: false, maxLength: 50),
                        Ankunft = c.DateTime(nullable: false),
                        Memo = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.PatientenNr);
            
            CreateTable(
                "dbo.Tablettes",
                c => new
                    {
                        TabletID = c.Int(nullable: false, identity: true),
                        TablettenName = c.String(nullable: false, maxLength: 50),
                        StueckZahl = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.TabletID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Arzts", "PatientenNr", "dbo.Patients");
            DropIndex("dbo.Arzts", new[] { "PatientenNr" });
            DropTable("dbo.Tablettes");
            DropTable("dbo.Patients");
            DropTable("dbo.Arzts");
        }
    }
}
