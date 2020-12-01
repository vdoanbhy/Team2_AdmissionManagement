namespace Team2_AdmissionManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SSN = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        MiddleName = c.String(nullable: false),
                        FirstName = c.String(),
                        Gender = c.Int(),
                        DoB = c.DateTime(nullable: false),
                        Street = c.String(),
                        City = c.String(),
                        State = c.Int(),
                        Zip = c.Int(nullable: false),
                        HomePhone = c.String(nullable: false),
                        CellPhone = c.String(nullable: false),
                        InstitutionName = c.String(),
                        InstitutionCity = c.String(),
                        GraduationDate = c.DateTime(nullable: false),
                        GPA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MathSAT = c.Int(nullable: false),
                        VerbalSAT = c.Int(nullable: false),
                        InterestID = c.Int(),
                        SubmissionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Interests", t => t.InterestID)
                .Index(t => t.InterestID);
            
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Major = c.String(),
                        Terms = c.Int(nullable: false),
                        Year = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ApplicantID = c.Int(nullable: false),
                        Decision = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Applicants", t => t.ApplicantID, cascadeDelete: true)
                .Index(t => t.ApplicantID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "ApplicantID", "dbo.Applicants");
            DropForeignKey("dbo.Applicants", "InterestID", "dbo.Interests");
            DropIndex("dbo.Reviews", new[] { "ApplicantID" });
            DropIndex("dbo.Applicants", new[] { "InterestID" });
            DropTable("dbo.Reviews");
            DropTable("dbo.Interests");
            DropTable("dbo.Applicants");
        }
    }
}
