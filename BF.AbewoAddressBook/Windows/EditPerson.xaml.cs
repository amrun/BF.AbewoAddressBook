using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BF.AbewoAdressBook.Entities;

namespace BF.AbewoAdressBook.Windows
{
	/// <summary>
	/// Interaction logic for EditPerson.xaml
	/// </summary>
	public partial class EditPerson : Window
	{

		public EditPerson( int personId )
		{

			InitializeComponent();

			this.PersonId = personId;
			using( var db = new AbewoAddressBookContext() )
			{
				var query = from b in db.Persons
							where b.personId.Equals( this.PersonId )
							select b;

				if( query.First().Gender.Equals( false ) )
				{
					RbEditMale.IsChecked = true;
				}
				else
				{
					RbEditFemale.IsChecked = true;
				}
				TbEditName.Text = query.First().Name;
				TbEditSurname.Text = query.First().Surname;
				TbEditEMail.Text = query.First().Email;
				TbEditSurname.Text = query.First().Surname;
				TbEditName.Text = query.First().Name;
				TbEditPlz.Text = query.First().Plz;
				TbEditStreet.Text = query.First().Street;
				TbEditStreetNr.Text = query.First().StreetNr;
			}
		}

		private void PersonButtonUpdateClick( object sender, RoutedEventArgs e )
		{


			using( var db = new AbewoAddressBookContext() )
			{
				var query = from b in db.Persons
							where b.personId.Equals( this.PersonId )
							select b;

				if( RbEditMale.IsChecked == true )
				{
					query.First().Gender = false;
				}
				else if( RbEditFemale.IsChecked == true )
				{
					query.First().Gender = true;
				}

				query.First().Name = TbEditName.Text;
				query.First().Surname = TbEditSurname.Text;
				query.First().Email = TbEditEMail.Text;
				query.First().Surname = TbEditSurname.Text;
				query.First().Plz = TbEditPlz.Text;
				query.First().Street = TbEditStreet.Text;
				query.First().StreetNr = TbEditStreetNr.Text;

				db.SaveChanges();

			}

			//Octopus.UpdatePerson( Pp );
		}

		protected int PersonId
		{
			get;
			set;
		}

		private void ButtonCancelClick( object sender, RoutedEventArgs e )
		{
			this.Close();
		}

		private void PersonButtonUpdateAndCloseClick( object sender, RoutedEventArgs e )
		{
			PersonButtonUpdateClick( sender, e );
			this.Close();
		}
	}
}
