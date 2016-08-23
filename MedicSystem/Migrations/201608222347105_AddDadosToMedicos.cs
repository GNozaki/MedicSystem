namespace MedicSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDadosToMedicos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medicos", "DadosPessoaisId", c => c.Long(nullable: false));
            CreateIndex("dbo.Medicos", "DadosPessoaisId");
            AddForeignKey("dbo.Medicos", "DadosPessoaisId", "dbo.DadosPessoais", "DadosId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicos", "DadosPessoaisId", "dbo.DadosPessoais");
            DropIndex("dbo.Medicos", new[] { "DadosPessoaisId" });
            DropColumn("dbo.Medicos", "DadosPessoaisId");
        }
    }
}
