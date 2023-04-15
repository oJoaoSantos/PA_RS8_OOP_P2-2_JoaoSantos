namespace RSGymAdministrative_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M01Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        ZipCodeID = c.Int(nullable: false),
                        ClientName = c.String(nullable: false, maxLength: 100),
                        BirthDate = c.DateTime(nullable: false),
                        ClientVat = c.String(nullable: false),
                        ClientPhoneNumber = c.String(nullable: false),
                        ClientEmail = c.String(nullable: false),
                        ClientAdress = c.String(nullable: false, maxLength: 200),
                        ClientObservations = c.String(maxLength: 255),
                        ActiveNow = c.Boolean(nullable: false),
                        PersonalTrainer_PersonalTrainerID = c.Int(),
                    })
                .PrimaryKey(t => t.ClientID)
                .ForeignKey("dbo.PersonalTrainer", t => t.PersonalTrainer_PersonalTrainerID)
                .ForeignKey("dbo.ZipCode", t => t.ZipCodeID, cascadeDelete: true)
                .Index(t => t.ZipCodeID)
                .Index(t => t.PersonalTrainer_PersonalTrainerID);
            
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        RequestID = c.Int(nullable: false, identity: true),
                        ClientID = c.Int(nullable: false),
                        PersonalTrainerID = c.Int(nullable: false),
                        DateAndTime = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        RequestObservations = c.String(maxLength: 255),
                        PersonalTrainer_PersonalTrainerID = c.Int(),
                    })
                .PrimaryKey(t => t.RequestID)
                .ForeignKey("dbo.Client", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.PersonalTrainer", t => t.PersonalTrainer_PersonalTrainerID)
                .ForeignKey("dbo.PersonalTrainer", t => t.PersonalTrainerID)
                .Index(t => t.ClientID)
                .Index(t => t.PersonalTrainerID)
                .Index(t => t.PersonalTrainer_PersonalTrainerID);
            
            CreateTable(
                "dbo.PersonalTrainer",
                c => new
                    {
                        PersonalTrainerID = c.Int(nullable: false, identity: true),
                        ZipCodeID = c.Int(nullable: false),
                        PtCode = c.String(nullable: false, maxLength: 4),
                        PtName = c.String(nullable: false, maxLength: 100),
                        PtVat = c.String(nullable: false),
                        PtPhoneNumber = c.String(nullable: false),
                        PtEmail = c.String(nullable: false),
                        PtAdress = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.PersonalTrainerID)
                .ForeignKey("dbo.ZipCode", t => t.ZipCodeID, cascadeDelete: true)
                .Index(t => t.ZipCodeID);
            
            CreateTable(
                "dbo.ZipCode",
                c => new
                    {
                        ZipCodeID = c.Int(nullable: false, identity: true),
                        Zip = c.String(nullable: false),
                        City = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ZipCodeID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 100),
                        Code = c.String(nullable: false, maxLength: 6),
                        PassWord = c.String(nullable: false),
                        PermissionType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Request", "PersonalTrainerID", "dbo.PersonalTrainer");
            DropForeignKey("dbo.PersonalTrainer", "ZipCodeID", "dbo.ZipCode");
            DropForeignKey("dbo.Client", "ZipCodeID", "dbo.ZipCode");
            DropForeignKey("dbo.Request", "PersonalTrainer_PersonalTrainerID", "dbo.PersonalTrainer");
            DropForeignKey("dbo.Client", "PersonalTrainer_PersonalTrainerID", "dbo.PersonalTrainer");
            DropForeignKey("dbo.Request", "ClientID", "dbo.Client");
            DropIndex("dbo.PersonalTrainer", new[] { "ZipCodeID" });
            DropIndex("dbo.Request", new[] { "PersonalTrainer_PersonalTrainerID" });
            DropIndex("dbo.Request", new[] { "PersonalTrainerID" });
            DropIndex("dbo.Request", new[] { "ClientID" });
            DropIndex("dbo.Client", new[] { "PersonalTrainer_PersonalTrainerID" });
            DropIndex("dbo.Client", new[] { "ZipCodeID" });
            DropTable("dbo.User");
            DropTable("dbo.ZipCode");
            DropTable("dbo.PersonalTrainer");
            DropTable("dbo.Request");
            DropTable("dbo.Client");
        }
    }
}
