using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BF.AbewoAdressBook.Entities
{
	public class Person
	{
		public int personId
		{
			get;
			set;
		}
		public bool Gender
		{
			get;
			set;
		}
		public string Name
		{
			get;
			set;
		}
		public string Surname
		{
			get;
			set;
		}
		public string Street
		{
			get;
			set;
		}
		public string StreetNr
		{
			get;
			set;
		}
		public string Plz
		{
			get;
			set;
		}
		public string City
		{
			get;
			set;
		}
		public string Email
		{
			get;
			set;
		}
		public string Company
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the whole list of <see cref="Person"/> from the DB
		/// </summary>
		/// <param name="searchWord">The word to search for</param>
		/// <returns></returns>
		public static List<Person> GetAllPersons( string searchWord = "" )
		{
			List<Person> persons = new List<Person>();

			using( var db = new AbewoAddressBookContext() )
			{
				var query = from b in db.Persons
							where ( b.Name.Contains( searchWord ) || b.Surname.Contains( searchWord ) || b.Email.Contains( searchWord ) || b.Company.Contains( searchWord ) || b.City.Contains( searchWord ) )
							orderby b.Name
							select b;

				foreach( Person person in query )
				{
					persons.Add( person );
				}
			}

			return persons;
		}

		/// <summary>
		/// Saves the <see cref="Person"/>.
		/// </summary>
		/// <param name="person">person</param>
		/// <returns></returns>
		public static bool Save( Person person )
		{
			using( var db = new AbewoAddressBookContext() )
			{
				db.Persons.Add( person );
				db.SaveChanges();
			}
			return true;
		}

		/// <summary>
		/// Updates the <see cref="Person"/>.
		/// </summary>
		/// <param name="person">person</param>
		/// <returns></returns>
		public static bool Update( Person person )
		{
			using( var db = new AbewoAddressBookContext() )
			{
				db.SaveChanges();
			}
			return true;
		}

		public static bool Delete( int PersonId )
		{
			using( var db = new AbewoAddressBookContext() )
			{
				var query = from b in db.Persons
							where b.personId.Equals( PersonId )
							select b;

				db.Persons.Remove( query.First() );
				db.SaveChanges();
			}

			return true;
		}
	}

}
