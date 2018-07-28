namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationMovie : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime());
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Int());
            AlterColumn("dbo.Movies", "Name", c => c.String());
        }
    }
}
