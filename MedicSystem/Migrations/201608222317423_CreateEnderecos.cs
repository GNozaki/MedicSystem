namespace MedicSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEnderecos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enderecos",
                c => new
                    {
                        EnderecoId = c.Long(nullable: false, identity: true),
                        Pais = c.String(),
                        Estado = c.String(),
                        Cidade = c.String(),
                        Bairro = c.String(),
                        Logradouro = c.String(),
                        NumeroLocal = c.String(),
                        Cep = c.String(),
                    })
                .PrimaryKey(t => t.EnderecoId);
            
            DropColumn("dbo.Clinicas", "Cidade");
            DropColumn("dbo.Clinicas", "Estado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clinicas", "Estado", c => c.String());
            AddColumn("dbo.Clinicas", "Cidade", c => c.String());
            DropTable("dbo.Enderecos");
        }
    }
}
