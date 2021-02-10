namespace PatientenAkte.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jetztaber : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TablettePatients",
                c => new
                    {
                        Tablette_TabletID = c.Int(nullable: false),
                        Patient_PatientenNr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tablette_TabletID, t.Patient_PatientenNr })
                .ForeignKey("dbo.Tablettes", t => t.Tablette_TabletID, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.Patient_PatientenNr, cascadeDelete: true)
                .Index(t => t.Tablette_TabletID)
                .Index(t => t.Patient_PatientenNr);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TablettePatients", "Patient_PatientenNr", "dbo.Patients");
            DropForeignKey("dbo.TablettePatients", "Tablette_TabletID", "dbo.Tablettes");
            DropIndex("dbo.TablettePatients", new[] { "Patient_PatientenNr" });
            DropIndex("dbo.TablettePatients", new[] { "Tablette_TabletID" });
            DropTable("dbo.TablettePatients");
        }
    }
}
