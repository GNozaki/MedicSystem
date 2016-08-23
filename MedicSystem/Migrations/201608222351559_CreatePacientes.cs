namespace MedicSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePacientes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        PacienteId = c.Long(nullable: false, identity: true),
                        EnderecoId = c.Long(),
                        DadosPessoaisId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.PacienteId)
                .ForeignKey("dbo.DadosPessoais", t => t.DadosPessoaisId, cascadeDelete: true)
                .ForeignKey("dbo.Enderecos", t => t.EnderecoId)
                .Index(t => t.EnderecoId)
                .Index(t => t.DadosPessoaisId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pacientes", "EnderecoId", "dbo.Enderecos");
            DropForeignKey("dbo.Pacientes", "DadosPessoaisId", "dbo.DadosPessoais");
            DropIndex("dbo.Pacientes", new[] { "DadosPessoaisId" });
            DropIndex("dbo.Pacientes", new[] { "EnderecoId" });
            DropTable("dbo.Pacientes");
        }
    }
}
