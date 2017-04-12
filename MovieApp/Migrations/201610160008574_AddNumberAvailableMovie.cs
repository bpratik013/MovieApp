namespace MovieApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberAvailableMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvailabel", c => c.Byte(nullable: false));

            Sql("UPDATE Movies SET NumberAvailabel = Stock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberAvailabel");
        }
    }
}
