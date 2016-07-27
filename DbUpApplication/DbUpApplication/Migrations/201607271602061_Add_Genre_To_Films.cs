namespace DbUpApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Genre_To_Films : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Films", "Genre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Films", "Genre");
        }
    }
}
