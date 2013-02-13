using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using BF.AbewoAdressBook.Entities;

namespace BF.AbewoAdressBook
{
	static class Main
	{

		//public static void Main( string[] args )
		//{
		//	//MainWindow mainWindow = new MainWindow();
		//	Console.WriteLine( "blubb" );
		//}

		public static List<Person> ReadAllDbContent()
		{
			List<Person> persons = new List<Person>();

			Person p1 = new Person();
			p1.Name = "Hans Meier";
			p1.Surname = "MeinVorname";
			p1.Email = "hansmeier@meier.ch";

			Person p2 = new Person();
			p2.Name = "Joggeli Müller";
			p2.Surname = "MeinVorname";
			p2.Email = "joggi@meier.ch";

			using( var db = new AbewoAddressBookContext() )
			{
				var query = from b in db.Persons
							orderby b.Name
							select b;

				foreach( Person person in query )
				{
					persons.Add( person );
				}
			}

			return persons;
		}
	}
}
