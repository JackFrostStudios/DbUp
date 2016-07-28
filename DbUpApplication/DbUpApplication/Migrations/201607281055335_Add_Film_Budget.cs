namespace DbUpApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Film_Budget : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Films", "Budget", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Films", "Budget");
        }
    }
}
