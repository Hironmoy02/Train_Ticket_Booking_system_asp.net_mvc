namespace Rail_Booking_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Booking",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        From = c.String(),
                        To = c.String(nullable: false),
                        BookingDate = c.DateTime(nullable: false),
                        NumberOfPassengers = c.Int(nullable: false),
                        RailId = c.Int(nullable: false),
                        ScheduleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Rails", t => t.RailId, cascadeDelete: true)
                .ForeignKey("dbo.Schedules", t => t.ScheduleId, cascadeDelete: false)
                .ForeignKey("dbo.UserLogin", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.RailId)
                .Index(t => t.ScheduleId);
            
            CreateTable(
                "dbo.Rails",
                c => new
                    {
                        RailId = c.Int(nullable: false, identity: true),
                        TrainId = c.Int(nullable: false),
                        StationId = c.Int(nullable: false),
                        From = c.String(nullable: false),
                        To = c.String(nullable: false),
                        FromCode = c.String(),
                        ToCode = c.String(),
                        ArrivalTime = c.String(nullable: false),
                        DepartureTime = c.String(nullable: false),
                        TotalSeatsCapacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RailId)
                .ForeignKey("dbo.Station", t => t.StationId, cascadeDelete: true)
                .ForeignKey("dbo.Train", t => t.TrainId, cascadeDelete: true)
                .Index(t => t.TrainId)
                .Index(t => t.StationId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        From = c.String(),
                        To = c.String(),
                        RailDate = c.DateTime(nullable: false),
                        ArrivalTime = c.String(),
                        DepartureTime = c.String(),
                        Price = c.Single(nullable: false),
                        RailId = c.Int(nullable: false),
                        TrainId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleId)
                .ForeignKey("dbo.Rails", t => t.RailId, cascadeDelete: false)
                .ForeignKey("dbo.Train", t => t.TrainId, cascadeDelete: true)
                .Index(t => t.RailId)
                .Index(t => t.TrainId);
            
            CreateTable(
                "dbo.Train",
                c => new
                    {
                        TrainId = c.Int(nullable: false, identity: true),
                        TrainName = c.String(nullable: false, maxLength: 30),
                        SeatingCapacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrainId);
            
            CreateTable(
                "dbo.Station",
                c => new
                    {
                        StationId = c.Int(nullable: false, identity: true),
                        StationName = c.String(nullable: false, maxLength: 30),
                        City = c.String(nullable: false, maxLength: 30),
                        Country = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.StationId);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 40),
                        LastName = c.String(nullable: false, maxLength: 40),
                        Email = c.String(nullable: false, maxLength: 20),
                        Role = c.String(),
                        Password = c.String(nullable: false, maxLength: 16),
                        ConfirmPassword = c.String(maxLength: 16),
                        Age = c.Int(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentDate = c.DateTime(nullable: false),
                        PaymentMode = c.String(),
                        UserName = c.String(),
                        CardType = c.String(),
                        CardNo = c.Long(nullable: false),
                        CVV = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BookingId = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        ScheduleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Booking", t => t.BookingId, cascadeDelete: true)
                .ForeignKey("dbo.Schedules", t => t.ScheduleId, cascadeDelete: false)
                .ForeignKey("dbo.UserLogin", t => t.UserID, cascadeDelete: false)
                .Index(t => t.BookingId)
                .Index(t => t.UserID)
                .Index(t => t.ScheduleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Booking", "UserID", "dbo.UserLogin");
            DropForeignKey("dbo.Payments", "UserID", "dbo.UserLogin");
            DropForeignKey("dbo.Payments", "ScheduleId", "dbo.Schedules");
            DropForeignKey("dbo.Payments", "BookingId", "dbo.Booking");
            DropForeignKey("dbo.Booking", "ScheduleId", "dbo.Schedules");
            DropForeignKey("dbo.Booking", "RailId", "dbo.Rails");
            DropForeignKey("dbo.Rails", "TrainId", "dbo.Train");
            DropForeignKey("dbo.Rails", "StationId", "dbo.Station");
            DropForeignKey("dbo.Schedules", "TrainId", "dbo.Train");
            DropForeignKey("dbo.Schedules", "RailId", "dbo.Rails");
            DropIndex("dbo.Payments", new[] { "ScheduleId" });
            DropIndex("dbo.Payments", new[] { "UserID" });
            DropIndex("dbo.Payments", new[] { "BookingId" });
            DropIndex("dbo.Schedules", new[] { "TrainId" });
            DropIndex("dbo.Schedules", new[] { "RailId" });
            DropIndex("dbo.Rails", new[] { "StationId" });
            DropIndex("dbo.Rails", new[] { "TrainId" });
            DropIndex("dbo.Booking", new[] { "ScheduleId" });
            DropIndex("dbo.Booking", new[] { "RailId" });
            DropIndex("dbo.Booking", new[] { "UserID" });
            DropTable("dbo.Payments");
            DropTable("dbo.UserLogin");
            DropTable("dbo.Station");
            DropTable("dbo.Train");
            DropTable("dbo.Schedules");
            DropTable("dbo.Rails");
            DropTable("dbo.Booking");
        }
    }
}
