using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System.Windows.Media.Animation;
using BF.AbewoAdressBook.Entities;
using BF.AbewoAdressBook.Windows;

namespace BF.AbewoAdressBook
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// Automatically load the list of the persons.
	/// </summary>
	public partial class MainWindow: Window
	{
		public MainWindow()
		{
			InitializeComponent();
			UpdateResultlist();
		}

		/// <summary>
		/// Updates the resultlist (The main list of the program displaying the persons).
		/// </summary>
		private void UpdateResultlist()
		{
			List<Person> personList = Octopus.GetAllPersonsFromDb();
			try
			{
				ResultList.ItemsSource = personList;
			}
			catch (Exception m)
			{
			}
		}

		/// <summary>
		/// On change in the TbSearchField, update the list.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
		public void TbSearchField_TextChanged( object sender, TextChangedEventArgs e )
		{
			List<Person> personList = Octopus.GetAllPersonsFromDb( TbSearchField.Text );

			try
			{
				ResultList.ItemsSource = personList;
			}
			catch
			{
			}
		}



		/// <summary>
		/// Handle the click on the Save button.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
		private void PersonButtonSave_Click( object sender, RoutedEventArgs e )
		{
			Person person = new Person();
			person.Name = TbName.Text;
			person.Surname = TbSurname.Text;
			person.Street = TbStreet.Text;
			person.StreetNr = TbStreetNr.Text;
			person.Email = TbEMail.Text;

			Octopus.SavePerson( person );

		}

		/// <summary>
		/// Handle the click on the edit button inside the list.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
		private void PersonButtonEditPerson_Click( object sender, RoutedEventArgs e )
		{
			ResultList.SelectedItem = ( (Button)sender ).DataContext;
			Person editPerson = (Person)ResultList.SelectedItem;

			Window editWindow = new EditPerson( editPerson.personId );

			editWindow.ShowDialog();

			UpdateResultlist();
		}
	}
}
