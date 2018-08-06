namespace tess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inclusaodatacadastro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produto", "DataCadatro", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produto", "DataCadatro");
        }
    }
}
