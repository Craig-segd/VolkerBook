namespace VolkerBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAdministratorAcc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "Administrator", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "Administrator");
        }
    }
}
