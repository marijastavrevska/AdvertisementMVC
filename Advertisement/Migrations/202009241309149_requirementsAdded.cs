namespace Advertisement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requirementsAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ads", "Description", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ads", "Description", c => c.String(nullable: false));
        }
    }
}
