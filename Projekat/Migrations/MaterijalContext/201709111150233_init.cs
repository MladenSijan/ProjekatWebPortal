namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaterijalModels",
                c => new
                    {
                        materijalId = c.Int(nullable: false, identity: true),
                        materijalFile = c.Binary(),
                        fileMimeType = c.String(),
                        materijalOpis = c.String(),
                        predmetId = c.Int(nullable: false),
                        materijalEkstenzija = c.String(),
                        materijalNaziv = c.String(),
                    })
                .PrimaryKey(t => t.materijalId)
                .ForeignKey("dbo.PredmetModels", t => t.predmetId, cascadeDelete: true)
                .Index(t => t.predmetId);
            
            CreateTable(
                "dbo.PredmetModels",
                c => new
                    {
                        predmetId = c.Int(nullable: false, identity: true),
                        predmetNaziv = c.String(),
                        predmetOpis = c.String(),
                    })
                .PrimaryKey(t => t.predmetId);
            
            CreateTable(
                "dbo.PremetPoSmerus",
                c => new
                    {
                        predmetId = c.Int(nullable: false),
                        smerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.predmetId, t.smerId })
                .ForeignKey("dbo.PredmetModels", t => t.predmetId, cascadeDelete: true)
                .ForeignKey("dbo.SmerModels", t => t.smerId, cascadeDelete: true)
                .Index(t => t.predmetId)
                .Index(t => t.smerId);
            
            CreateTable(
                "dbo.SmerModels",
                c => new
                    {
                        smerId = c.Int(nullable: false, identity: true),
                        smerNaziv = c.String(),
                        smerOpis = c.String(),
                    })
                .PrimaryKey(t => t.smerId);
            
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
           
        }
    }
}
