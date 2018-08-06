namespace tess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteracao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produto", "DataCadastro", c => c.DateTime(nullable: false));
            DropColumn("dbo.Produto", "DataCadatro");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produto", "DataCadatro", c => c.DateTime(nullable: false));
            DropColumn("dbo.Produto", "DataCadastro");
        }
    }
}
