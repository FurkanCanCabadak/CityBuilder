namespace CityBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStructureLvl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Areas", "StructureLvl", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Areas", "StructureLvl");
        }
    }
}
