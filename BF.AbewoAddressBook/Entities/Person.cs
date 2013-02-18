using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BF.AbewoAdressBook.Entities
{
	public class Person
	{
		/// <summary>
		/// Gets or sets the person id.
		/// </summary>
		/// <value>
		/// The person id.
		/// </value>
		public int personId
		{
			get;
			set;
		}
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Person"/> is gender.
		/// </summary>
		/// <value>
		///   <c>true</c> if gender; otherwise, <c>false</c>.
		/// </value>
		public bool Gender
		{
			get;
			set;
		}
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name
		{
			get;
			set;
		}
		/// <summary>
		/// Gets or sets the surname.
		/// </summary>
		/// <value>
		/// The surname.
		/// </value>
		public string Surname
		{
			get;
			set;
		}
		/// <summary>
		/// Gets or sets the street.
		/// </summary>
		/// <value>
		/// The street.
		/// </value>
		public string Street
		{
			get;
			set;
		}
		/// <summary>
		/// Gets or sets the street nr.
		/// </summary>
		/// <value>
		/// The street nr.
		/// </value>
		public string StreetNr
		{
			get;
			set;
		}
		/// <summary>
		/// Gets or sets the PLZ.
		/// </summary>
		/// <value>
		/// The PLZ.
		/// </value>
		public string Plz
		{
			get;
			set;
		}
		/// <summary>
		/// Gets or sets the city.
		/// </summary>
		/// <value>
		/// The city.
		/// </value>
		public string City
		{
			get;
			set;
		}
		/// <summary>
		/// Gets or sets the email.
		/// </summary>
		/// <value>
		/// The email.
		/// </value>
		public string Email
		{
			get;
			set;
		}
		//public Company Company { get; set; }

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
				            where ( b.Name.Contains( searchWord ) || b.Surname.Contains( searchWord ) || b.Email.Contains( searchWord ) )
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

		public static bool Delete(int PersonId)
		{
			using (var db = new AbewoAddressBookContext())
			{
				var query = from b in db.Persons
				            where b.personId.Equals(PersonId)
				            select b;

				db.Persons.Remove(query.First());
				db.SaveChanges();
			}

			return true;
		}
	}

}
