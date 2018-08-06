namespace tess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validacao1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categoria", "Nome", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Pessoa", "Nome", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Pessoa", "sobrenome", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Fabricante", "Nome", c => c.String(nullable: false, maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fabricante", "Nome", c => c.String());
            AlterColumn("dbo.Pessoa", "sobrenome", c => c.String());
            AlterColumn("dbo.Pessoa", "Nome", c => c.String());
            AlterColumn("dbo.Categoria", "Nome", c => c.String());
        }
    }
}
