namespace Restaurante.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddsRestaurantEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurants",
                c => new {
                    id = c.Int(nullable: false, identity: true),
                    name = c.String(nullable: false, maxLength: 80, unicode: false),
                    active = c.Boolean(nullable: false),
                    created_at = c.DateTime(nullable: false),
                    updated_at = c.DateTime(),
                    deleted_at = c.DateTime(),
                }
            )
            .PrimaryKey(t => t.id, name: "pk_Restaurants")
            .Index(t => t.name, unique: true, name: "ak_Restaurants");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Restaurants", "ak_Restaurants");
            DropTable("dbo.Restaurants");
        }
    }
}
