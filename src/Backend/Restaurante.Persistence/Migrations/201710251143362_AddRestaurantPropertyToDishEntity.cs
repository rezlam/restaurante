namespace Restaurante.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRestaurantPropertyToDishEntity : DbMigration
    {
        public override void Up()
        {
            //AddForeignKey("dbo.Dishes", "restaurant_id", "dbo.Restaurants", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
           // DropForeignKey("dbo.Dishes", "restaurant_id", "dbo.Restaurants");
        }
    }
}
