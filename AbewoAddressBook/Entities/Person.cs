using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbewoAddressBook.Entities
{
	class Person
	{
		public bool Gender { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Street { get; set; }
		public string StreetNr { get; set; }
		public string Plz { get; set; }
		public string City { get; set; }
		public string Email { get; set; }
		public Company Company { get; set; }

	}
}
