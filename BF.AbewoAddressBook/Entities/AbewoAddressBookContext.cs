using System.Data.Entity;

namespace BF.AbewoAdressBook.Entities
{
	public class AbewoAddressBookContext : DbContext
	{
		public DbSet<Person> Persons { get; set; }
		public DbSet<Company> Companies { get; set; }
	}
}