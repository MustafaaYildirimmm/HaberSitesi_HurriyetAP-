namespace HaberSitesiBitirmeProjesi.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Members", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "Photo");
            DropColumn("dbo.Comments", "Date");
        }
    }
}
