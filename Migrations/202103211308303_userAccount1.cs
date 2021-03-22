namespace ChetuProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userAccount1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserAccounts", "ProfileImage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserAccounts", "ProfileImage", c => c.String(nullable: false));
        }
    }
}
