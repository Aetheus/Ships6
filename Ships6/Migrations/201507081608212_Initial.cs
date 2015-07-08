namespace Ships6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cabins",
                c => new
                    {
                        CabinID = c.Int(nullable: false, identity: true),
                        CruiseID = c.Int(nullable: false),
                        CabinTypeID = c.Int(nullable: false),
                        CabinIsOccupied = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CabinID)
                .ForeignKey("dbo.CabinTypes", t => t.CabinTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Cruises", t => t.CruiseID, cascadeDelete: true)
                .Index(t => t.CruiseID)
                .Index(t => t.CabinTypeID);
            
            CreateTable(
                "dbo.CabinTypes",
                c => new
                    {
                        CabinTypeID = c.Int(nullable: false, identity: true),
                        CabinTypeName = c.String(),
                        CabinTypePrice = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.CabinTypeID);
            
            CreateTable(
                "dbo.Cruises",
                c => new
                    {
                        CruiseID = c.Int(nullable: false, identity: true),
                        OperatorID = c.Int(nullable: false),
                        CruiseName = c.String(),
                        CruiseDescription = c.String(),
                        CruiseImage = c.Binary(),
                        CruisePrice = c.Decimal(nullable: false, storeType: "money"),
                        CruiseDepartureTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CruiseDayLength = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CruiseID)
                .ForeignKey("dbo.Operators", t => t.OperatorID, cascadeDelete: true)
                .Index(t => t.OperatorID);
            
            CreateTable(
                "dbo.Operators",
                c => new
                    {
                        OperatorID = c.Int(nullable: false, identity: true),
                        OperatorName = c.String(),
                    })
                .PrimaryKey(t => t.OperatorID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.CruiseDestinations",
                c => new
                    {
                        CruiseID = c.Int(nullable: false),
                        DestinationID = c.Int(nullable: false),
                        tripOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CruiseID, t.DestinationID, t.tripOrder })
                .ForeignKey("dbo.Cruises", t => t.CruiseID, cascadeDelete: true)
                .ForeignKey("dbo.Destinations", t => t.DestinationID, cascadeDelete: true)
                .Index(t => t.CruiseID)
                .Index(t => t.DestinationID);
            
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        DestinationID = c.Int(nullable: false, identity: true),
                        DestinationName = c.String(),
                        DestinationCountry = c.String(),
                        DestinationImage = c.Binary(),
                    })
                .PrimaryKey(t => t.DestinationID);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationID = c.Int(nullable: false, identity: true),
                        CruiseID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        CabinID = c.Int(nullable: false),
                        ReservationTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ReservationPrice = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.ReservationID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Gender = c.String(),
                        CreditCard = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CruiseDestinations", "DestinationID", "dbo.Destinations");
            DropForeignKey("dbo.CruiseDestinations", "CruiseID", "dbo.Cruises");
            DropForeignKey("dbo.Cabins", "CruiseID", "dbo.Cruises");
            DropForeignKey("dbo.Cruises", "OperatorID", "dbo.Operators");
            DropForeignKey("dbo.Cabins", "CabinTypeID", "dbo.CabinTypes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UserProfiles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.CruiseDestinations", new[] { "DestinationID" });
            DropIndex("dbo.CruiseDestinations", new[] { "CruiseID" });
            DropIndex("dbo.Cruises", new[] { "OperatorID" });
            DropIndex("dbo.Cabins", new[] { "CabinTypeID" });
            DropIndex("dbo.Cabins", new[] { "CruiseID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Reservations");
            DropTable("dbo.Destinations");
            DropTable("dbo.CruiseDestinations");
            DropTable("dbo.Contacts");
            DropTable("dbo.Operators");
            DropTable("dbo.Cruises");
            DropTable("dbo.CabinTypes");
            DropTable("dbo.Cabins");
        }
    }
}
