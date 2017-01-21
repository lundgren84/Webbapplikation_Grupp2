namespace Network_layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Account",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        UserName = c.String(),
                        Email = c.String(),
                        ImgURL = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_Account");
        }
    }
}
