namespace Advertisement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        ImgUrl = c.String(),
                        Date = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.String(nullable: false),
                        customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.customer_Id)
                .Index(t => t.customer_Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ads", "customer_Id", "dbo.Customers");
            DropIndex("dbo.Ads", new[] { "customer_Id" });
            DropTable("dbo.Customers");
            DropTable("dbo.Ads");
        }
    }
}
