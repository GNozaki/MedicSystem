namespace MedicSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDadosPessoais : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DadosPessoais",
                c => new
                    {
                        DadosId = c.Long(nullable: false, identity: true),
                        Cpf = c.String(),
                        Nome = c.String(nullable: false),
                        Nascimento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DadosId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DadosPessoais");
        }
    }
}
