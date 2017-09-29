namespace VolkerBook.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class DatabaseInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    MemberId = c.Guid(nullable: false),
                    FirstName = c.String(nullable: false, maxLength: 100),
                    LastName = c.String(nullable: false, maxLength: 100),
                    PhoneNumber = c.String(nullable: false, maxLength: 100),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Members");
        }
    }
}
