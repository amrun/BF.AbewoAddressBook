using System.Data.Entity;

namespace BF.AbewoAdressBook.Entities
{
	public class Person
	{
		public int personId { get; set; }
		public bool Gender { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Street { get; set; }
		public string StreetNr { get; set; }
		public string Plz { get; set; }
		public string City { get; set; }
		public string Email { get; set; }
		//public Company Company { get; set; }

	}



}
