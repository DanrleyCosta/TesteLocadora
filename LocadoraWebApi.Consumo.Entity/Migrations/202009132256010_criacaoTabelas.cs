namespace LocadoraWebApi.Consumo.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criacaoTabelas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Locacaos", "DataDevolucao", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locacaos", "DataDevolucao", c => c.DateTime());
        }
    }
}
