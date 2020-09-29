namespace Advertisement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Ads", "Category_Id", c => c.Int());
            CreateIndex("dbo.Ads", "Category_Id");
            AddForeignKey("dbo.Ads", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ads", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Ads", new[] { "Category_Id" });
            DropColumn("dbo.Ads", "Category_Id");
            DropTable("dbo.Categories");
        }
    }
}
