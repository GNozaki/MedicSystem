namespace MedicSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectClinicasMedicos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicosClinicas",
                c => new
                    {
                        Medicos_MedicoId = c.Long(nullable: false),
                        Clinicas_ClinicaId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Medicos_MedicoId, t.Clinicas_ClinicaId })
                .ForeignKey("dbo.Medicos", t => t.Medicos_MedicoId, cascadeDelete: true)
                .ForeignKey("dbo.Clinicas", t => t.Clinicas_ClinicaId, cascadeDelete: true)
                .Index(t => t.Medicos_MedicoId)
                .Index(t => t.Clinicas_ClinicaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicosClinicas", "Clinicas_ClinicaId", "dbo.Clinicas");
            DropForeignKey("dbo.MedicosClinicas", "Medicos_MedicoId", "dbo.Medicos");
            DropIndex("dbo.MedicosClinicas", new[] { "Clinicas_ClinicaId" });
            DropIndex("dbo.MedicosClinicas", new[] { "Medicos_MedicoId" });
            DropTable("dbo.MedicosClinicas");
        }
    }
}
