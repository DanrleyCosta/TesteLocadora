namespace LocadoraWebApi.Consumo.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabelas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locacaos", "Filme_Id", "dbo.Filmes");
            DropIndex("dbo.Locacaos", new[] { "Filme_Id" });
            DropPrimaryKey("dbo.Locacaos");
            DropPrimaryKey("dbo.Filmes");
            AlterColumn("dbo.Locacaos", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Locacaos", "Filme_Id", c => c.Int());
            AlterColumn("dbo.Filmes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Locacaos", "Id");
            AddPrimaryKey("dbo.Filmes", "Id");
            CreateIndex("dbo.Locacaos", "Filme_Id");
            AddForeignKey("dbo.Locacaos", "Filme_Id", "dbo.Filmes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locacaos", "Filme_Id", "dbo.Filmes");
            DropIndex("dbo.Locacaos", new[] { "Filme_Id" });
            DropPrimaryKey("dbo.Filmes");
            DropPrimaryKey("dbo.Locacaos");
            AlterColumn("dbo.Filmes", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Locacaos", "Filme_Id", c => c.Long());
            AlterColumn("dbo.Locacaos", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Filmes", "Id");
            AddPrimaryKey("dbo.Locacaos", "Id");
            CreateIndex("dbo.Locacaos", "Filme_Id");
            AddForeignKey("dbo.Locacaos", "Filme_Id", "dbo.Filmes", "Id");
        }
    }
}
