namespace PatientenAkte.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nextVersuch : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PatientTablettNMPatients", new[] { "PatientTablettNM_PatientenNr", "PatientTablettNM_TablettenID" }, "dbo.PatientTablettNMs");
            DropForeignKey("dbo.PatientTablettNMPatients", "Patient_PatientenNr", "dbo.Patients");
            DropForeignKey("dbo.Tablettes", new[] { "PatientTablettNM_PatientenNr", "PatientTablettNM_TablettenID" }, "dbo.PatientTablettNMs");
            DropIndex("dbo.Tablettes", new[] { "PatientTablettNM_PatientenNr", "PatientTablettNM_TablettenID" });
            DropIndex("dbo.PatientTablettNMPatients", new[] { "PatientTablettNM_PatientenNr", "PatientTablettNM_TablettenID" });
            DropIndex("dbo.PatientTablettNMPatients", new[] { "Patient_PatientenNr" });
            DropColumn("dbo.Tablettes", "PatientTablettNM_PatientenNr");
            DropColumn("dbo.Tablettes", "PatientTablettNM_TablettenID");
            DropTable("dbo.PatientTablettNMs");
            DropTable("dbo.PatientTablettNMPatients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PatientTablettNMPatients",
                c => new
                    {
                        PatientTablettNM_PatientenNr = c.Int(nullable: false),
                        PatientTablettNM_TablettenID = c.Int(nullable: false),
                        Patient_PatientenNr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PatientTablettNM_PatientenNr, t.PatientTablettNM_TablettenID, t.Patient_PatientenNr });
            
            CreateTable(
                "dbo.PatientTablettNMs",
                c => new
                    {
                        PatientenNr = c.Int(nullable: false),
                        TablettenID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PatientenNr, t.TablettenID });
            
            AddColumn("dbo.Tablettes", "PatientTablettNM_TablettenID", c => c.Int());
            AddColumn("dbo.Tablettes", "PatientTablettNM_PatientenNr", c => c.Int());
            CreateIndex("dbo.PatientTablettNMPatients", "Patient_PatientenNr");
            CreateIndex("dbo.PatientTablettNMPatients", new[] { "PatientTablettNM_PatientenNr", "PatientTablettNM_TablettenID" });
            CreateIndex("dbo.Tablettes", new[] { "PatientTablettNM_PatientenNr", "PatientTablettNM_TablettenID" });
            AddForeignKey("dbo.Tablettes", new[] { "PatientTablettNM_PatientenNr", "PatientTablettNM_TablettenID" }, "dbo.PatientTablettNMs", new[] { "PatientenNr", "TablettenID" });
            AddForeignKey("dbo.PatientTablettNMPatients", "Patient_PatientenNr", "dbo.Patients", "PatientenNr", cascadeDelete: true);
            AddForeignKey("dbo.PatientTablettNMPatients", new[] { "PatientTablettNM_PatientenNr", "PatientTablettNM_TablettenID" }, "dbo.PatientTablettNMs", new[] { "PatientenNr", "TablettenID" }, cascadeDelete: true);
        }
    }
}
