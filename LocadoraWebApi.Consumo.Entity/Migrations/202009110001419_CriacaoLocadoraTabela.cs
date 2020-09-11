namespace LocadoraWebApi.Consumo.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoLocadoraTabela : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Locacao_Id", c => c.Int());
            AddColumn("dbo.Filmes", "EstoqueFilme", c => c.Int(nullable: false));
            AddColumn("dbo.Filmes", "Locacao_Id", c => c.Int());
            CreateIndex("dbo.Clientes", "Locacao_Id");
            CreateIndex("dbo.Filmes", "Locacao_Id");
            AddForeignKey("dbo.Clientes", "Locacao_Id", "dbo.Locacaos", "Id");
            AddForeignKey("dbo.Filmes", "Locacao_Id", "dbo.Locacaos", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Filmes", "Locacao_Id", "dbo.Locacaos");
            DropForeignKey("dbo.Clientes", "Locacao_Id", "dbo.Locacaos");
            DropIndex("dbo.Filmes", new[] { "Locacao_Id" });
            DropIndex("dbo.Clientes", new[] { "Locacao_Id" });
            DropColumn("dbo.Filmes", "Locacao_Id");
            DropColumn("dbo.Filmes", "EstoqueFilme");
            DropColumn("dbo.Clientes", "Locacao_Id");
        }
    }
}
