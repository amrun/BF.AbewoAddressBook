using System.Linq;
using System.Windows;
using BF.AbewoAdressBook.Entities;

namespace BF.AbewoAdressBook.Windows
{
	/// <summary>
	/// Interaction logic for EditPerson.xaml
	/// </summary>
	public partial class EditPerson : Window
	{
		/// <summary>
		/// Prepares the EditPerson form with the data of the person to edit.
		/// </summary>
		/// <param name="personId">The id of the person to edit</param>
		public EditPerson( int personId )
		{
			InitializeComponent();

			PersonId = personId;
			using( var db = new AbewoAddressBookContext() )
			{
				IQueryable<Person> query = from b in db.Persons
										   where b.personId.Equals( PersonId )
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

		/// <summary>
		/// Gets or sets the person id.
		/// </summary>
		/// <value>
		/// The person id.
		/// </value>
		private int PersonId
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the data from the form and updates the person which was edited.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
		private void PersonButtonUpdateClick( object sender, RoutedEventArgs e )
		{
			using( var db = new AbewoAddressBookContext() )
			{
				IQueryable<Person> query = from b in db.Persons
										   where b.personId.Equals( PersonId )
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

		}

		/// <summary>
		/// Closes the editPerson window, doing nothing to the database.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
		private void ButtonCancelClick( object sender, RoutedEventArgs e )
		{
			Close();
		}

		/// <summary>
		/// Calls the <see cref="PersonButtonUpdateClick"/> method to save the changes and closes the editPerson window.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
		private void PersonButtonUpdateAndCloseClick( object sender, RoutedEventArgs e )
		{
			PersonButtonUpdateClick( sender, e );
			Close();
		}
	}
}