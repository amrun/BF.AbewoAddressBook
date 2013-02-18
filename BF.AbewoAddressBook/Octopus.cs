using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using BF.AbewoAdressBook.Entities;

namespace BF.AbewoAdressBook
{
	static class Octopus
	{

		/// <summary>
		/// Gets the whole list of <see cref="Person"/> from the DB
		/// </summary>
		/// <param name="searchWord">The word to search for</param>
		/// <returns></returns>
		public static List<Person> GetAllPersonsFromDb( string searchWord = "" )
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
		public static bool SavePerson( Person person )
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
		public static bool UpdatePerson( Person person )
		{
			using( var db = new AbewoAddressBookContext() )
			{
				db.SaveChanges();
			}
			return true;
		}
	}
}
