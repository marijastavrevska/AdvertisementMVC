namespace Advertisement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesCategory : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ads", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ads", "Category", c => c.String(nullable: false));
        }
    }
}
