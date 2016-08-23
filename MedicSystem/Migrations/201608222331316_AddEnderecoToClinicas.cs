namespace MedicSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnderecoToClinicas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clinicas", "EnderecoId", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clinicas", "EnderecoId");
        }
    }
}
