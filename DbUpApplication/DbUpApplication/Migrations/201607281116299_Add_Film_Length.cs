namespace DbUpApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Film_Length : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Films", "Length", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Films", "Length");
        }
    }
}
