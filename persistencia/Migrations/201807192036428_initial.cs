namespace tess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaId = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        ProdutoId = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        Quantidade = c.Int(nullable: false),
                        CategoriaId = c.Long(nullable: false),
                        FabricanteId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Fabricante", t => t.FabricanteId, cascadeDelete: true)
                .Index(t => t.CategoriaId)
                .Index(t => t.FabricanteId);
            
            CreateTable(
                "dbo.Compra",
                c => new
                    {
                        CompraId = c.Long(nullable: false, identity: true),
                        DataCompra = c.DateTime(nullable: false),
                        ProdutoId = c.Long(nullable: false),
                        PessoaId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.CompraId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId, cascadeDelete: true)
                .ForeignKey("dbo.Produto", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.ProdutoId)
                .Index(t => t.PessoaId);
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        sobrenome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fabricante",
                c => new
                    {
                        FabricanteID = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.FabricanteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "FabricanteId", "dbo.Fabricante");
            DropForeignKey("dbo.Compra", "ProdutoId", "dbo.Produto");
            DropForeignKey("dbo.Compra", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Produto", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Compra", new[] { "PessoaId" });
            DropIndex("dbo.Compra", new[] { "ProdutoId" });
            DropIndex("dbo.Produto", new[] { "FabricanteId" });
            DropIndex("dbo.Produto", new[] { "CategoriaId" });
            DropTable("dbo.Fabricante");
            DropTable("dbo.Pessoa");
            DropTable("dbo.Compra");
            DropTable("dbo.Produto");
            DropTable("dbo.Categoria");
        }
    }
}
