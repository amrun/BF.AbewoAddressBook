using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using BF.AbewoAdressBook.Entities;
using BF.AbewoAdressBook.Windows;
using Brushes = System.Windows.Media.Brushes;
using Button = System.Windows.Controls.Button;

namespace BF.AbewoAdressBook
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// Automatically load the list of the persons.
	/// </summary>
	public partial class MainWindow : Window
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
			List<Person> personList = Person.GetAllPersons();
			try
			{
				ResultList.ItemsSource = personList;
			}
			catch( Exception m )
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
			List<Person> personList = Person.GetAllPersons( TbSearchField.Text );

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
			bool save = true;


			// Check Gender
			if( RbEditMale.IsChecked == true )
			{
				person.Gender = false;
			}
			else if( RbEditFemale.IsChecked == true )
			{
				RbEditMale.Background = Brushes.White;
				RbEditFemale.Background = Brushes.White;
				person.Gender = true;
			}
			else
			{
				RbEditMale.Background = Brushes.Red;
				RbEditFemale.Background = Brushes.Red;
				save = false;
			}

			// Check Name
			if( TbName.Text != "" )
			{
				TbName.Background = Brushes.White;
				person.Name = TbName.Text;
			}
			else
			{
				TbName.Background = Brushes.Red;
				save = false;
			}

			// Check Surname
			if( TbSurname.Text != "" )
			{
				TbSurname.Background = Brushes.White;
				person.Surname = TbSurname.Text;
			}
			else
			{
				TbSurname.Background = Brushes.Red;
				save = false;
			}

			// Check Street
			if( TbStreet.Text != "" )
			{
				person.Street = TbStreet.Text;
				TbStreet.Background = Brushes.White;
			}
			else
			{
				TbStreet.Background = Brushes.Red;
				save = false;
			}

			// Check StreetNr
			if( TbStreetNr.Text != "" )
			{
				TbStreetNr.Background = Brushes.White;
				person.StreetNr = TbStreetNr.Text;
			}
			else
			{
				TbStreetNr.Background = Brushes.Red;
				save = false;
			}

			// Check City
			if( TbCity.Text != "" )
			{
				TbCity.Background = Brushes.White;
				person.City = TbCity.Text;
			}
			else
			{
				TbCity.Background = Brushes.Red;
				save = false;
			}

			// Check Plz
			if( TbPlz.Text != "" )
			{
				TbPlz.Background = Brushes.White;
				person.Plz = TbPlz.Text;
			}
			else
			{
				TbPlz.Background = Brushes.Red;
				save = false;
			}

			// Check Mail
			if( TbEMail.Text != "" )
			{
				TbEMail.Background = Brushes.White;
				person.Email = TbEMail.Text;
			}
			else
			{
				TbEMail.Background = Brushes.Red;
				save = false;
			}

			// Save if everything is ok
			if( save )
			{
				Person.Save( person );
			}

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

		private void ResultList_SelectionChanged( object sender, SelectionChangedEventArgs e )
		{

		}

		private void PersonButtonCancel_Click( object sender, RoutedEventArgs e )
		{
			Search.IsSelected = true;
		}

		private void PersonButtonDelete_Click( object sender, RoutedEventArgs e )
		{
			ResultList.SelectedItem = ( (Button)sender ).DataContext;
			Person deletePerson = (Person)ResultList.SelectedItem;
			Person.Delete( deletePerson.personId );
			UpdateResultlist();
		}

		private void PersonButtonSendMail_Click( object sender, RoutedEventArgs e )
		{
			ResultList.SelectedItem = ( (Button)sender ).DataContext;
			Person mailPerson = (Person)ResultList.SelectedItem;
			Process.Start( "mailto:" + mailPerson.Email );

			// TODO: test notification possibilities
			NotifyIcon test = new NotifyIcon();
			test.Icon = SystemIcons.Information;
			test.Visible = true;
			test.ShowBalloonTip( 3, "E-Mail", "Mail an " + mailPerson.Name + " " + mailPerson.Surname + " geöffnet", ToolTipIcon.Info );
			test.Visible = false;
		}
	}
}