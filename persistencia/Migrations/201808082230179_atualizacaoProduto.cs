namespace tess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizacaoProduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produto", "LogotipoMimeType", c => c.String());
            AddColumn("dbo.Produto", "LogoTipo", c => c.Binary());
            AddColumn("dbo.Produto", "NomeArquivo", c => c.String());
            AddColumn("dbo.Produto", "TamanhoArquivo", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produto", "TamanhoArquivo");
            DropColumn("dbo.Produto", "NomeArquivo");
            DropColumn("dbo.Produto", "LogoTipo");
            DropColumn("dbo.Produto", "LogotipoMimeType");
        }
    }
}
