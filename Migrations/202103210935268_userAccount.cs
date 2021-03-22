namespace ChetuProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userAccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                        Email = c.String(nullable: false),
                        gender = c.Int(nullable: false),
                        MobileNo = c.String(nullable: false),
                        ProfileImage = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserAccounts");
        }
    }
}
