namespace WebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigrate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusStops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Number = c.Int(nullable: false),
                        Direction = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        Lat = c.Double(nullable: false),
                        Long = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BusStops");
        }
    }
}
