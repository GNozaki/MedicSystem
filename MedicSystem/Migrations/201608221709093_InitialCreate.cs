namespace MedicSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clinicas",
                c => new
                    {
                        ClinicaId = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        Cidade = c.String(),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.ClinicaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clinicas");
        }
    }
}
