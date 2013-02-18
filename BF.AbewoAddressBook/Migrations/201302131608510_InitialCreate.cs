namespace BF.AbewoAdressBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        personId = c.Int(nullable: false, identity: true),
                        Gender = c.Boolean(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Street = c.String(),
                        StreetNr = c.String(),
                        Plz = c.String(),
                        City = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.personId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        companyId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.companyId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Companies");
            DropTable("dbo.People");
        }
    }
}
