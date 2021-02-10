namespace PatientenAkte.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FK : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientTablettNMs",
                c => new
                    {
                        PatientenNr = c.Int(nullable: false),
                        TablettenID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PatientenNr, t.TablettenID });
            
            CreateTable(
                "dbo.PatientTablettNMPatients",
                c => new
                    {
                        PatientTablettNM_PatientenNr = c.Int(nullable: false),
                        PatientTablettNM_TablettenID = c.Int(nullable: false),
                        Patient_PatientenNr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PatientTablettNM_PatientenNr, t.PatientTablettNM_TablettenID, t.Patient_PatientenNr })
                .ForeignKey("dbo.PatientTablettNMs", t => new { t.PatientTablettNM_PatientenNr, t.PatientTablettNM_TablettenID }, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.Patient_PatientenNr, cascadeDelete: true)
                .Index(t => new { t.PatientTablettNM_PatientenNr, t.PatientTablettNM_TablettenID })
                .Index(t => t.Patient_PatientenNr);
            
            AddColumn("dbo.Tablettes", "PatientTablettNM_PatientenNr", c => c.Int());
            AddColumn("dbo.Tablettes", "PatientTablettNM_TablettenID", c => c.Int());
            CreateIndex("dbo.Tablettes", new[] { "PatientTablettNM_PatientenNr", "PatientTablettNM_TablettenID" });
            AddForeignKey("dbo.Tablettes", new[] { "PatientTablettNM_PatientenNr", "PatientTablettNM_TablettenID" }, "dbo.PatientTablettNMs", new[] { "PatientenNr", "TablettenID" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tablettes", new[] { "PatientTablettNM_PatientenNr", "PatientTablettNM_TablettenID" }, "dbo.PatientTablettNMs");
            DropForeignKey("dbo.PatientTablettNMPatients", "Patient_PatientenNr", "dbo.Patients");
            DropForeignKey("dbo.PatientTablettNMPatients", new[] { "PatientTablettNM_PatientenNr", "PatientTablettNM_TablettenID" }, "dbo.PatientTablettNMs");
            DropIndex("dbo.PatientTablettNMPatients", new[] { "Patient_PatientenNr" });
            DropIndex("dbo.PatientTablettNMPatients", new[] { "PatientTablettNM_PatientenNr", "PatientTablettNM_TablettenID" });
            DropIndex("dbo.Tablettes", new[] { "PatientTablettNM_PatientenNr", "PatientTablettNM_TablettenID" });
            DropColumn("dbo.Tablettes", "PatientTablettNM_TablettenID");
            DropColumn("dbo.Tablettes", "PatientTablettNM_PatientenNr");
            DropTable("dbo.PatientTablettNMPatients");
            DropTable("dbo.PatientTablettNMs");
        }
    }
}
