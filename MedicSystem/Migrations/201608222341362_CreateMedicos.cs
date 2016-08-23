namespace MedicSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMedicos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        MedicoId = c.Long(nullable: false, identity: true),
                        Crm = c.String(),
                        Especialidade = c.String(),
                        EnderecoId = c.Long(),
                    })
                .PrimaryKey(t => t.MedicoId)
                .ForeignKey("dbo.Enderecos", t => t.EnderecoId)
                .Index(t => t.EnderecoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicos", "EnderecoId", "dbo.Enderecos");
            DropIndex("dbo.Medicos", new[] { "EnderecoId" });
            DropTable("dbo.Medicos");
        }
    }
}
