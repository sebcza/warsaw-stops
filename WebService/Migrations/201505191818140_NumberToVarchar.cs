namespace WebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumberToVarchar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BusStops", "Number", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BusStops", "Number", c => c.Int(nullable: false));
        }
    }
}
