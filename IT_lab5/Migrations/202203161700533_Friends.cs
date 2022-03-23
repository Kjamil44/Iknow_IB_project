namespace IT_lab5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Friends : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Subject = c.String(nullable: false),
                    Grade = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Friends");
        }
    }
}
