namespace tess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validacao : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produto", "Nome", c => c.String(nullable: false, maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produto", "Nome", c => c.String());
        }
    }
}
