namespace ParkingSpace.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParkingTickets",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        PlateNo = c.String(),
                        GateID = c.Int(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        DateOut = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ParkingTickets");
        }
    }
}
