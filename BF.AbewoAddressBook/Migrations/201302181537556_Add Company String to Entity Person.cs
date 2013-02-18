namespace BF.AbewoAdressBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyStringtoEntityPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Company", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Company");
        }
    }
}
