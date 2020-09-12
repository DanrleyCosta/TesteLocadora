namespace LocadoraWebApi.Consumo.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabelas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientes", "Locacao_Id", "dbo.Locacaos");
            DropForeignKey("dbo.Filmes", "Locacao_Id", "dbo.Locacaos");
            DropIndex("dbo.Clientes", new[] { "Locacao_Id" });
            DropIndex("dbo.Filmes", new[] { "Locacao_Id" });
            DropPrimaryKey("dbo.Filmes");
            DropPrimaryKey("dbo.Locacaos");
            AddColumn("dbo.Clientes", "Saldo", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Filmes", "Titulo", c => c.String());
            AddColumn("dbo.Filmes", "Creditos", c => c.Int(nullable: false));
            AddColumn("dbo.Locacaos", "DataLocacao", c => c.DateTime(nullable: false));
            AddColumn("dbo.Locacaos", "FId", c => c.Int(nullable: false));
            AddColumn("dbo.Locacaos", "CId", c => c.Int(nullable: false));
            AddColumn("dbo.Locacaos", "Cliente_Id", c => c.Int());
            AddColumn("dbo.Locacaos", "Filme_Id", c => c.Long());
            AlterColumn("dbo.Filmes", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Locacaos", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Locacaos", "DataDevolucao", c => c.DateTime());
            AddPrimaryKey("dbo.Filmes", "Id");
            AddPrimaryKey("dbo.Locacaos", "Id");
            CreateIndex("dbo.Locacaos", "Cliente_Id");
            CreateIndex("dbo.Locacaos", "Filme_Id");
            AddForeignKey("dbo.Locacaos", "Cliente_Id", "dbo.Clientes", "Id");
            AddForeignKey("dbo.Locacaos", "Filme_Id", "dbo.Filmes", "Id");
            DropColumn("dbo.Clientes", "Locacao_Id");
            DropColumn("dbo.Filmes", "NomeFilme");
            DropColumn("dbo.Filmes", "EstoqueFilme");
            DropColumn("dbo.Filmes", "Locacao_Id");
            DropColumn("dbo.Locacaos", "DataEmprestimo");
            DropColumn("dbo.Locacaos", "Estoque");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locacaos", "Estoque", c => c.Int(nullable: false));
            AddColumn("dbo.Locacaos", "DataEmprestimo", c => c.DateTime(nullable: false));
            AddColumn("dbo.Filmes", "Locacao_Id", c => c.Int());
            AddColumn("dbo.Filmes", "EstoqueFilme", c => c.Int(nullable: false));
            AddColumn("dbo.Filmes", "NomeFilme", c => c.String());
            AddColumn("dbo.Clientes", "Locacao_Id", c => c.Int());
            DropForeignKey("dbo.Locacaos", "Filme_Id", "dbo.Filmes");
            DropForeignKey("dbo.Locacaos", "Cliente_Id", "dbo.Clientes");
            DropIndex("dbo.Locacaos", new[] { "Filme_Id" });
            DropIndex("dbo.Locacaos", new[] { "Cliente_Id" });
            DropPrimaryKey("dbo.Locacaos");
            DropPrimaryKey("dbo.Filmes");
            AlterColumn("dbo.Locacaos", "DataDevolucao", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Locacaos", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Filmes", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Locacaos", "Filme_Id");
            DropColumn("dbo.Locacaos", "Cliente_Id");
            DropColumn("dbo.Locacaos", "CId");
            DropColumn("dbo.Locacaos", "FId");
            DropColumn("dbo.Locacaos", "DataLocacao");
            DropColumn("dbo.Filmes", "Creditos");
            DropColumn("dbo.Filmes", "Titulo");
            DropColumn("dbo.Clientes", "Saldo");
            AddPrimaryKey("dbo.Locacaos", "Id");
            AddPrimaryKey("dbo.Filmes", "Id");
            CreateIndex("dbo.Filmes", "Locacao_Id");
            CreateIndex("dbo.Clientes", "Locacao_Id");
            AddForeignKey("dbo.Filmes", "Locacao_Id", "dbo.Locacaos", "Id");
            AddForeignKey("dbo.Clientes", "Locacao_Id", "dbo.Locacaos", "Id");
        }
    }
}
