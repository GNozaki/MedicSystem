namespace MedicSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstForeignKey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Clinicas", "EnderecoId");
            AddForeignKey("dbo.Clinicas", "EnderecoId", "dbo.Enderecos", "EnderecoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clinicas", "EnderecoId", "dbo.Enderecos");
            DropIndex("dbo.Clinicas", new[] { "EnderecoId" });
        }
    }
}
