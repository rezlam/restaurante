namespace Restaurante.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddsDishesEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dishes",
                c => new {
                    id = c.Int(nullable: false, identity: true),
                    restaurant_id = c.Int(nullable: false),
                    name = c.String(nullable: false, maxLength: 80, unicode: false),
                    price = c.Decimal(nullable: false, precision: 8, scale: 2),
                    active = c.Boolean(nullable: false),
                    created_at = c.DateTime(nullable: false),
                    updated_at = c.DateTime(),
                    deleted_at = c.DateTime(),
                }
            )
            .PrimaryKey(t => t.id, name: "pk_Dishes")
            .ForeignKey("dbo.Restaurants", t => t.restaurant_id, cascadeDelete: true, name: "fk_Dishes_Restaurants")
            .Index(t => new { t.restaurant_id, t.name }, unique: true, name: "ak_Dishes");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dishes", "restaurant_id", "dbo.Restaurants");
            DropIndex("dbo.Dishes", "ak_Dishes");
            DropTable("dbo.Dishes");
        }
    }
}
