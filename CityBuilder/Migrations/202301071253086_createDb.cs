namespace CityBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GetMoney = c.Double(nullable: false),
                        CityId = c.Int(nullable: false),
                        StructureId = c.Int(nullable: false),
                        IsBuildId = c.Int(nullable: false),
                        LocationX = c.Int(nullable: false),
                        LocationY = c.Int(nullable: false),
                        IsCollect = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        IsStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.IsBuilds", t => t.IsBuildId, cascadeDelete: true)
                .ForeignKey("dbo.Structures", t => t.StructureId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.StructureId)
                .Index(t => t.IsBuildId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PlayerId = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        IsStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Money = c.Double(nullable: false),
                        Password = c.String(),
                        Email = c.String(),
                        Age = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        IsStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IsBuilds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        IsStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Structures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UpgradeTime = c.Time(nullable: false, precision: 7),
                        Income = c.Double(nullable: false),
                        Level = c.Int(nullable: false),
                        MaxLevel = c.Int(nullable: false),
                        Cost = c.Double(nullable: false),
                        StructureImage = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        IsStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Areas", "StructureId", "dbo.Structures");
            DropForeignKey("dbo.Areas", "IsBuildId", "dbo.IsBuilds");
            DropForeignKey("dbo.Cities", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Areas", "CityId", "dbo.Cities");
            DropIndex("dbo.Cities", new[] { "PlayerId" });
            DropIndex("dbo.Areas", new[] { "IsBuildId" });
            DropIndex("dbo.Areas", new[] { "StructureId" });
            DropIndex("dbo.Areas", new[] { "CityId" });
            DropTable("dbo.Structures");
            DropTable("dbo.IsBuilds");
            DropTable("dbo.Players");
            DropTable("dbo.Cities");
            DropTable("dbo.Areas");
        }
    }
}
