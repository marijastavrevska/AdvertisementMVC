namespace Advertisement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeInAccounts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ads", "customer_Id", "dbo.Customers");
            DropIndex("dbo.Ads", new[] { "customer_Id" });
            DropColumn("dbo.Ads", "customer_Id");
            DropTable("dbo.Customers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        ImgUrl = c.String(),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Ads", "customer_Id", c => c.Int());
            CreateIndex("dbo.Ads", "customer_Id");
            AddForeignKey("dbo.Ads", "customer_Id", "dbo.Customers", "Id");
        }
    }
}
