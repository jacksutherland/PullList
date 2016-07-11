namespace PullList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeStoreNameRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Store", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Store", "Name", c => c.String());
        }
    }
}
