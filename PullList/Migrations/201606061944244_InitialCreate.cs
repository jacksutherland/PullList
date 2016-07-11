namespace PullList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.UserProfile",
            //    c => new
            //    {
            //        UserId = c.Int(nullable: false, identity: true),
            //        UserName = c.String(),
            //    })
            //    .PrimaryKey(t => t.UserId);

            CreateTable(
                "dbo.UserDetail",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.Int(nullable: false),
                    Active = c.Boolean(nullable: false),
                    IsAdmin = c.Boolean(nullable: false),
                    FirstName = c.String(),
                    LastName = c.String(),
                    Email = c.String(),
                    Phone = c.String(),
                    SMSNotifications = c.Boolean(nullable: false),
                    EmailNotifications = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            AddForeignKey("dbo.UserDetail", "UserId", "pulllist.UserProfile", "UserId");
            CreateIndex("dbo.UserDetail", "UserId");

            CreateTable(
                "dbo.Store",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Active = c.Boolean(nullable: false),
                    Name = c.String(),
                    Email = c.String(),
                    Phone = c.String(),
                    Address = c.String(),
                    PullType = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Customer",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    StoreId = c.Int(nullable: false),
                    UserId = c.Int(nullable: false)
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Store", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId);

            AddForeignKey("dbo.Customer", "UserId", "pulllist.UserProfile", "UserId");
            CreateIndex("dbo.Customer", "UserId");

            CreateTable(
                "dbo.Employee",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    StoreId = c.Int(nullable: false),
                    UserId = c.Int(nullable: false),
                    Type = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Store", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId);

            AddForeignKey("dbo.Employee", "UserId", "pulllist.UserProfile", "UserId");
            CreateIndex("dbo.Employee", "UserId");

            CreateTable(
                "dbo.Publisher",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Active = c.Boolean(nullable: false),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Series",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Active = c.Boolean(nullable: false),
                    PublisherId = c.Int(nullable: false),
                    Title = c.String(),
                    ReleaseDate = c.DateTime(),
                    Volume = c.Int(nullable: false),
                    Image = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Publisher", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.PublisherId);

            CreateTable(
                "dbo.Subscription",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Active = c.Boolean(nullable: false),
                    UserId = c.Int(nullable: false),
                    StoreId = c.Int(nullable: false),
                    CreatedDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                //.ForeignKey("pulllist.UserProfile", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Store", t => t.StoreId, cascadeDelete: true)
                //.Index(t => t.UserId)
                .Index(t => t.StoreId);

            AddForeignKey("dbo.Subscription", "UserId", "pulllist.UserProfile", "UserId");
            CreateIndex("dbo.Subscription", "UserId");

            CreateTable(
                "dbo.Pull",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    SeriesId = c.Int(nullable: false),
                    SubscriptionId = c.Int(nullable: false),
                    StartDate = c.DateTime(nullable: false),
                    EndDate = c.DateTime(nullable: true),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Series", t => t.SeriesId, cascadeDelete: true)
                .ForeignKey("dbo.Subscription", t => t.SubscriptionId, cascadeDelete: true)
                .Index(t => t.SeriesId)
                .Index(t => t.SubscriptionId);

        }

        public override void Down()
        {
            DropIndex("dbo.Pull", new[] { "SubscriptionId" });
            DropIndex("dbo.Pull", new[] { "SeriesId" });
            DropIndex("dbo.Subscription", new[] { "StoreId" });
            DropIndex("dbo.Subscription", new[] { "UserId" });
            DropIndex("dbo.Series", new[] { "PublisherId" });
            DropIndex("dbo.Customer", new[] { "UserId" });
            DropIndex("dbo.Customer", new[] { "StoreId" });
            DropIndex("dbo.Employee", new[] { "UserId" });
            DropIndex("dbo.Employee", new[] { "StoreId" });
            DropForeignKey("dbo.Pull", "SubscriptionId", "dbo.Subscription");
            DropForeignKey("dbo.Pull", "SeriesId", "dbo.Series");
            DropForeignKey("dbo.Subscription", "StoreId", "dbo.Store");
            DropForeignKey("dbo.Subscription", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Series", "PublisherId", "dbo.Publisher");
            DropForeignKey("dbo.Customer", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Customer", "StoreId", "dbo.Store");
            DropForeignKey("dbo.Employee", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Employee", "StoreId", "dbo.Store");
            DropTable("dbo.Pull");
            DropTable("dbo.Subscription");
            DropTable("dbo.Series");
            DropTable("dbo.Publisher");
            DropTable("dbo.Customer");
            DropTable("dbo.Employee");
            DropTable("dbo.Store");
            DropTable("dbo.UserDetail");
            DropTable("dbo.UserProfile");
        }
    }
}
