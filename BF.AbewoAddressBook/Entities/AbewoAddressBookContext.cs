using System.Data.Entity;

namespace BF.AbewoAdressBook.Entities
{
	/// <summary>
	/// Database context for the Entity Framework
	/// </summary>
	public class AbewoAddressBookContext : DbContext
	{
		/// <summary>
		/// Gets or sets the persons.
		/// </summary>
		/// <value>
		/// The persons.
		/// </value>
		public DbSet<Person> Persons { get; set; }
		
		/// <summary>
		/// Gets or sets the companies.
		/// </summary>
		/// <value>
		/// The companies.
		/// </value>
		public DbSet<Company> Companies { get; set; }
	}
}